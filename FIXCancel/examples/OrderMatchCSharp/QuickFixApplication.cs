using System;
using System.Collections.Generic;
using System.Diagnostics;
using QuickFix;

namespace OrderMatchCSharp
{
    public class QuickFixApplication : MessageCracker, QuickFix.Application
    {
        private readonly OrderMatcher _orderMatcher = new OrderMatcher();
        private readonly IDGenerator _idGenerator = new IDGenerator();
        private int _numberOfConnections = 0;

        private readonly IMatchingEngineView _view;

        public QuickFixApplication(IMatchingEngineView view)
        {
            _view = view;
        }

        #region Application Members

        public void onLogon(SessionID p1)
        {
            _view.WriteLineToConsole("Logged in: " + p1.getSenderCompID() + ", " + p1.getTargetCompID());
            _view.SetNumberOfConnections(++_numberOfConnections);
            _view.SetClientState(1, p1.getTargetCompID(), true);
        }

        public void onLogout(SessionID p1)
        {
            _view.WriteLineToConsole("Logged off: " + p1.getSenderCompID() + ", " + p1.getTargetCompID());
            _view.SetNumberOfConnections(--_numberOfConnections);
            _view.SetClientState(1, p1.getTargetCompID(), false);
        }

        public void toAdmin(Message p1, SessionID p2){}

        public void toApp(Message p1, SessionID p2) {}

        public void onCreate(SessionID p1) {}

        public void fromAdmin(Message p1, SessionID p2){}

        public void fromApp(Message p1, SessionID p2)
        {
            try
            {
                crack(p1, p2);
            }
            catch (FieldNotFound fieldNotFound)
            {
                Console.WriteLine("Field Not Found: " + fieldNotFound.Message);
            }
            catch (IncorrectDataFormat incorrectDataFormat)
            {
                Console.WriteLine("Incorrect Data Format: " + incorrectDataFormat.Message);
            }
            catch(IncorrectTagValue incorrectTagValue)
            {
                Console.WriteLine("Incorrect Tag Value: " + incorrectTagValue.Message);
            }
            catch(UnsupportedMessageType unsupportedMessageType)
            {
                Console.WriteLine("Unsupported Message Type: " + unsupportedMessageType.Message);
            }
            
        }

        #endregion

        public override void onMessage(QuickFix42.NewOrderSingle message, SessionID session)
        {
            SenderCompID senderCompId = new SenderCompID(message.getHeader().getField(SenderCompID.FIELD));
            TargetCompID targetCompId = new TargetCompID(message.getHeader().getField(TargetCompID.FIELD));
            ClOrdID clOrdID = message.getClOrdID();
            Symbol symbol = message.getSymbol();
            Side side = message.getSide();
            OrdType ordType = message.getOrdType();
            
            Price price = null;
            TimeInForce timeInForce = new TimeInForce(TimeInForce.DAY);

            if (ordType.getValue() == OrdType.LIMIT)
                price = message.getPrice();

            OrderQty orderQty = message.getOrderQty();
            if (message.isSetField(TimeInForce.FIELD))
                timeInForce = message.getTimeInForce();

            try
            {
                if (timeInForce.getValue() != TimeInForce.DAY)
                    throw new Exception("Unsupported TIF, use Day");

                Order order = new Order(clOrdID.getValue(), symbol.getValue(), 
                    senderCompId.getValue(), targetCompId.getValue(),
                    side, ordType, price.getValue(), orderQty.getValue());

                ProcessOrder(order);
            }
            catch (Exception e)
            {
                RejectOrder(senderCompId, targetCompId, clOrdID, symbol, side, e.Message);
            }
        }

        public override void onMessage(QuickFix42.OrderCancelRequest message, SessionID session)
        {
            OrigClOrdID origClOrdID = message.getOrigClOrdID();
            Symbol symbol = message.getSymbol();
            Side side = message.getSide();

            try
            {
                ProcessCancel(origClOrdID, symbol, side);
            }
            catch(Exception e)
            {
                Console.WriteLine("OrderCancelRequest error: " + e.Message);
            }
        }

        private void RejectOrder(SenderCompID senderCompId, TargetCompID targetCompId,
            ClOrdID clOrdID, Symbol symbol, Side side, string message)
        {
            QuickFix42.ExecutionReport executionReport = new QuickFix42.ExecutionReport(
                new OrderID(clOrdID.getValue()), new ExecID(_idGenerator.genExecutionID()),
                new ExecTransType(ExecTransType.NEW), new ExecType(ExecType.REJECTED),
                new OrdStatus(ExecType.REJECTED), symbol, side,
                new LeavesQty(0), new CumQty(0), new AvgPx(0));
            executionReport.set(clOrdID);
            executionReport.set(new Text(message));

            try
            {
                QuickFix.Session.sendToTarget(executionReport, senderCompId.getValue(), targetCompId.getValue());
            }
            catch (SessionNotFound snf)
            {
                Debug.WriteLine("RejectOrder: " + snf.Message);
            }
        }

        private void ProcessOrder(Order order)
        {
            if (_orderMatcher.insert(order))
            {
                AcceptOrder(order);

                List<Order> filledOrders = _orderMatcher.MatchAndReturnFills(order.Symbol);

                // fill Order
                foreach (Order filledOrder in filledOrders)
                    FillOrder(filledOrder);
            }
            else
                RejectOrder(order);
        }

        private void FillOrder(Order filledOrder)
        {
            UpdateOrder(filledOrder, 
                filledOrder.IsFilled() ? OrdStatus.FILLED : OrdStatus.PARTIALLY_FILLED);
        }

        private void AcceptOrder(Order order)
        {
            if (order.Side.getValue() == Side.BUY)
                _view.AddNewOrder(order);
            else if(order.Side.getValue() == Side.SELL)
                _view.AddNewOrder(order);

            UpdateOrder(order, OrdStatus.NEW);
        }

        private void UpdateOrder(Order order, char orderStatus)
        {
            TargetCompID targetCompID = new TargetCompID(order.Owner);
            SenderCompID senderCompID = new SenderCompID(order.Target);

            QuickFix42.ExecutionReport fixOrder = new QuickFix42.ExecutionReport(
                new OrderID(order.ClientId), 
                new ExecID(_idGenerator.genExecutionID()),
                new ExecTransType(ExecTransType.NEW),
                new ExecType(orderStatus),
                new OrdStatus(orderStatus), 
                new Symbol(order.Symbol),
                new Side(order.Side.getValue()), 
                new LeavesQty(order.OpenQuantity),
                new CumQty(order.ExecutedQuantity), 
                new AvgPx(order.AvgExecutedPrice)
                );

            fixOrder.set(new ClOrdID(order.ClientId));
            fixOrder.set(new OrderQty(order.Quantity));

            if (orderStatus == OrdStatus.FILLED || 
                orderStatus == OrdStatus.PARTIALLY_FILLED)
            {
                fixOrder.set(new LastShares(order.LastExecutedQuantity));
                fixOrder.set(new LastPx(order.LastExecutedPrice));
            }
            if (orderStatus == OrdStatus.CANCELED)
            {
                fixOrder.set(new QuickFix.LeavesQty(0));
            }

            try
            {
                Session.sendToTarget(fixOrder, senderCompID.ToString(), targetCompID.ToString());
            }
            catch (SessionNotFound snf)
            {
                Debug.WriteLine("UpdateOrder: " + snf.Message);
            }
        }

        private void RejectOrder(Order order)
        {
            UpdateOrder(order, OrdStatus.REJECTED);
        }

        private void ProcessCancel(OrigClOrdID id, Symbol symbol, Side side)
        {
            Order order = _view.CancelOrder(id.getValue());

            //Order order = _orderMatcher.find(symbol.getValue(), side, id.getValue());
            if (order != null)
            {
                //order.Cancel();
                CancelOrder(order);
                //_orderMatcher.erase(order);
            }
        }

        private void CancelOrder(Order order)
        {
            UpdateOrder(order, OrdStatus.CANCELED);
        }
    }
}