using System.Collections.Generic;
using NUnit.Framework;
using QuickFix;

namespace OrderMatchCSharp
{
    [TestFixture]
    public class OrderMatcherTests
    {
        private OrderMatcher _orderMatcher;
        private Order buy100GEAt1250;
        private Order buy200GEAt1250;
        private Order sell50GEAt1225;
        private Order sell50GEAt1225Copy;
        private Order sell50GEAt1200;
        private Order sell50GEAt1250;
        private Order sell50GEAt1300;

        [SetUp]
        public void SetUp()
        {
            buy100GEAt1250 = new Order(
                "101", "GE", "CLIENT1", "ORDERMATCH",
                new Side(Side.BUY), new OrdType(OrdType.LIMIT),
                12.50, 100);
            buy200GEAt1250 = new Order(
                "102", "GE", "CLIENT1", "ORDERMATCH",
                new Side(Side.BUY), new OrdType(OrdType.LIMIT),
                12.50, 200);
            sell50GEAt1225 = new Order(
                "103", "GE", "CLIENT2", "ORDERMATCH",
                new Side(Side.SELL), new OrdType(OrdType.LIMIT),
                12.25, 50);
            sell50GEAt1225Copy = new Order(
                "104", "GE", "CLIENT2", "ORDERMATCH",
                new Side(Side.SELL), new OrdType(OrdType.LIMIT),
                12.25, 50);
            sell50GEAt1200 = new Order(
                "105", "GE", "CLIENT2", "ORDERMATCH",
                new Side(Side.SELL), new OrdType(OrdType.LIMIT),
                12.00, 50);
            sell50GEAt1250 = new Order(
                "106", "GE", "CLIENT2", "ORDERMATCH",
                new Side(Side.SELL), new OrdType(OrdType.LIMIT),
                12.50, 50);
            sell50GEAt1300 = new Order(
                "107", "GE", "CLIENT2", "ORDERMATCH",
                new Side(Side.SELL), new OrdType(OrdType.LIMIT),
                13.00, 50);

            _orderMatcher = new OrderMatcher();
        }

        #region Order Insertion

        [Test]
        public void FindFirstInsertedOrder()
        {
            _orderMatcher.insert(buy100GEAt1250);

            Order foundOrder = _orderMatcher.find(buy100GEAt1250.Symbol, buy100GEAt1250.Side, buy100GEAt1250.ClientId);
            Assert.That(foundOrder.ClientId, Is.EqualTo(buy100GEAt1250.ClientId));
        }

        [Test]
        public void FindFirstOfTwoInsertedOrder()
        {
            _orderMatcher.insert(buy100GEAt1250);
            _orderMatcher.insert(sell50GEAt1225);

            Order foundOrder = _orderMatcher.find(buy100GEAt1250.Symbol, buy100GEAt1250.Side, buy100GEAt1250.ClientId);
            Assert.That(foundOrder.ClientId, Is.EqualTo(buy100GEAt1250.ClientId));
        }

        [Test]
        public void FindSecondInsertedOrder()
        {
            _orderMatcher.insert(buy100GEAt1250);
            _orderMatcher.insert(sell50GEAt1225);

            Order foundOrder = _orderMatcher.find(sell50GEAt1225.Symbol, sell50GEAt1225.Side, sell50GEAt1225.ClientId);
            Assert.That(foundOrder.ClientId, Is.EqualTo(sell50GEAt1225.ClientId));
        }

        #endregion Order Insertion

        #region Order Erase Tests

        [Test]
        public void EraseFirstOrder()
        {
            _orderMatcher.insert(buy100GEAt1250);

            Order foundOrder = _orderMatcher.find(buy100GEAt1250.Symbol, buy100GEAt1250.Side, buy100GEAt1250.ClientId);
            Assert.That(foundOrder.ClientId, Is.EqualTo(buy100GEAt1250.ClientId));

            _orderMatcher.erase(foundOrder);

            foundOrder = _orderMatcher.find(buy100GEAt1250.Symbol, buy100GEAt1250.Side, buy100GEAt1250.ClientId);
            Assert.That(foundOrder, Is.Null);
        }

        [Test]
        public void EraseFirstOfTwoOrders()
        {
            _orderMatcher.insert(buy100GEAt1250);
            _orderMatcher.insert(sell50GEAt1225);

            Order foundOrder = _orderMatcher.find(buy100GEAt1250.Symbol, buy100GEAt1250.Side, buy100GEAt1250.ClientId);
            Assert.That(foundOrder.ClientId, Is.EqualTo(buy100GEAt1250.ClientId));

            _orderMatcher.erase(foundOrder);

            foundOrder = _orderMatcher.find(buy100GEAt1250.Symbol, buy100GEAt1250.Side, buy100GEAt1250.ClientId);
            Assert.That(foundOrder, Is.Null);
        }

        [Test]
        public void EraseSecondofTwoOrders()
        {
            _orderMatcher.insert(buy100GEAt1250);
            _orderMatcher.insert(sell50GEAt1225);

            Order searchedOrder = _orderMatcher.find(sell50GEAt1225.Symbol, sell50GEAt1225.Side, sell50GEAt1225.ClientId);
            Assert.That(searchedOrder.ClientId, Is.EqualTo(sell50GEAt1225.ClientId));

            _orderMatcher.erase(sell50GEAt1225);

            searchedOrder = _orderMatcher.find(sell50GEAt1225.Symbol, sell50GEAt1225.Side, sell50GEAt1225.ClientId);
            Assert.That(searchedOrder, Is.Null);
        }

        #endregion Order Erase Tests

        #region Order Matching

        [Test]
        public void MatchOnce()
        {
            _orderMatcher.insert(buy100GEAt1250);
            _orderMatcher.insert(sell50GEAt1225);

            List<Order> fills = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(fills.Count, Is.EqualTo(2));

            Assert.That(buy100GEAt1250.AvgExecutedPrice, Is.EqualTo(12.25));
            Assert.That(buy100GEAt1250.OpenQuantity, Is.EqualTo(50));
            Assert.That(buy100GEAt1250.LastExecutedPrice, Is.EqualTo(12.25));
            Assert.That(buy100GEAt1250.LastExecutedQuantity, Is.EqualTo(50));

            Assert.That(sell50GEAt1225.AvgExecutedPrice, Is.EqualTo(12.25));
            Assert.That(sell50GEAt1225.OpenQuantity, Is.EqualTo(0));
            Assert.That(sell50GEAt1225.LastExecutedPrice, Is.EqualTo(12.25));
            Assert.That(sell50GEAt1225.LastExecutedQuantity, Is.EqualTo(50));
        }

        [Test]
        public void MatchTwice()
        {
            _orderMatcher.insert(buy100GEAt1250);
            _orderMatcher.insert(sell50GEAt1225);

            List<Order> orders = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(orders.Count, Is.EqualTo(2));

            Assert.That(buy100GEAt1250.AvgExecutedPrice, Is.EqualTo(12.25));
            Assert.That(buy100GEAt1250.OpenQuantity, Is.EqualTo(50));
            Assert.That(buy100GEAt1250.LastExecutedPrice, Is.EqualTo(12.25));
            Assert.That(buy100GEAt1250.LastExecutedQuantity, Is.EqualTo(50));

            Assert.That(sell50GEAt1225.AvgExecutedPrice, Is.EqualTo(12.25));
            Assert.That(sell50GEAt1225.OpenQuantity, Is.EqualTo(0));
            Assert.That(sell50GEAt1225.LastExecutedPrice, Is.EqualTo(12.25));
            Assert.That(sell50GEAt1225.LastExecutedQuantity, Is.EqualTo(50));

            _orderMatcher.insert(sell50GEAt1225Copy);
            List<Order> secondMatchOrders = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(secondMatchOrders.Count, Is.EqualTo(2));

            Assert.That(buy100GEAt1250.AvgExecutedPrice, Is.EqualTo(12.25));
            Assert.That(buy100GEAt1250.OpenQuantity, Is.EqualTo(0));
            Assert.That(buy100GEAt1250.LastExecutedPrice, Is.EqualTo(12.25));
            Assert.That(buy100GEAt1250.LastExecutedQuantity, Is.EqualTo(50));

            Assert.That(sell50GEAt1225.AvgExecutedPrice, Is.EqualTo(12.25));
            Assert.That(sell50GEAt1225.OpenQuantity, Is.EqualTo(0));
            Assert.That(sell50GEAt1225.LastExecutedPrice, Is.EqualTo(12.25));
            Assert.That(sell50GEAt1225.LastExecutedQuantity, Is.EqualTo(50));
        }

        [Test]
        public void MatchTwiceDifferentPrices()
        {
            _orderMatcher.insert(buy200GEAt1250);
            _orderMatcher.insert(sell50GEAt1200);

            List<Order> orders = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(orders.Count, Is.EqualTo(2));

            Assert.That(buy200GEAt1250.AvgExecutedPrice, Is.EqualTo(12.00));
            Assert.That(buy200GEAt1250.OpenQuantity, Is.EqualTo(150));
            Assert.That(buy200GEAt1250.LastExecutedPrice, Is.EqualTo(12.00));
            Assert.That(buy200GEAt1250.LastExecutedQuantity, Is.EqualTo(50));

            Assert.That(sell50GEAt1200.AvgExecutedPrice, Is.EqualTo(12.00));
            Assert.That(sell50GEAt1200.OpenQuantity, Is.EqualTo(0));
            Assert.That(sell50GEAt1200.LastExecutedPrice, Is.EqualTo(12.00));
            Assert.That(sell50GEAt1200.LastExecutedQuantity, Is.EqualTo(50));

            _orderMatcher.insert(sell50GEAt1250);
            List<Order> secondMatch = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(secondMatch.Count, Is.EqualTo(2));

            Assert.That(buy200GEAt1250.AvgExecutedPrice, Is.EqualTo(12.25));
            Assert.That(buy200GEAt1250.OpenQuantity, Is.EqualTo(100));
            Assert.That(buy200GEAt1250.LastExecutedPrice, Is.EqualTo(12.50));
            Assert.That(buy200GEAt1250.LastExecutedQuantity, Is.EqualTo(50));

            Assert.That(sell50GEAt1250.AvgExecutedPrice, Is.EqualTo(12.50));
            Assert.That(sell50GEAt1250.OpenQuantity, Is.EqualTo(0));
            Assert.That(sell50GEAt1250.LastExecutedPrice, Is.EqualTo(12.50));
            Assert.That(sell50GEAt1250.LastExecutedQuantity, Is.EqualTo(50));
        }

        [Test]
        public void ZeroMatchesZeroOrders()
        {
            List<Order> zeroMatches = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(zeroMatches.Count, Is.EqualTo(0));
        }

        [Test]
        public void ZeroMatchesTwoOrders()
        {
            _orderMatcher.insert(buy200GEAt1250);
            _orderMatcher.insert(sell50GEAt1300);

            List<Order> zeroMatches = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(zeroMatches.Count, Is.EqualTo(0));
        }

        [Test]
        public void MatchThreeOrders()
        {
            _orderMatcher.insert(buy100GEAt1250);
            _orderMatcher.insert(sell50GEAt1225);
            _orderMatcher.insert(sell50GEAt1225Copy);

            List<Order> threeMatches = _orderMatcher.MatchAndReturnFills("GE");
            Assert.That(threeMatches.Count, Is.EqualTo(4));

        }

        #endregion Order Matching
    }
}