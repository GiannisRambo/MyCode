using System;
using System.Collections;
using System.Collections.Generic;
using QuickFix;

namespace OrderMatchCSharp
{
    public class OrderMatcher
    {
        private readonly List<Order> _buys = new List<Order>();
        private readonly List<Order> _sells = new List<Order>();

        public bool insert(Order order)
        {
            if (order.Side.getValue() == Side.BUY)
            {
                _buys.Add(order);
                return true;
            }
            if (order.Side.getValue() == Side.SELL)
            {
                _sells.Add(order);
                return true;
            }

            return false;
        }

        public void erase(Order order)
        {
            if (order.Side.getValue() == Side.BUY)
            {
                _buys.Remove(order);
            }
            else if (order.Side.getValue() == Side.SELL)
            {
                _sells.Remove(order);
            }
        }

        public Order find(string symbol, Side side, string id)
        {
            List<Order> searchList = null;

            if (side.getValue() == Side.BUY)
            {
                searchList = _buys;
            }
            else if (side.getValue() == Side.SELL)
            {
                searchList = _sells;
            }
            foreach (Order order in searchList)
            {
                if (AreOrdersEqual(order, symbol, side, id))
                    return order;
            }
            return null;
        }

        private static bool AreOrdersEqual(Order order, string symbol, Side side, string id)
        {
            return (order.Symbol == symbol) && (order.Side == side) && (order.ClientId == id);
        }

        public List<Order> MatchAndReturnFills(string symbol)
        {
            List<Order> filledOrders = new List<Order>();

            if (_sells.Count == 0 || _buys.Count == 0 )
                return filledOrders;

            while (true)
            {
                List<Order> buyOrders = GetSortedOpenBuyOrders(symbol);
                List<Order> sellOrders = GetSortedOpenSellOrders(symbol);

                if (buyOrders == null || buyOrders.Count == 0 || sellOrders == null || sellOrders.Count == 0)
                    return filledOrders;

                List<Order>.Enumerator buyEnum = buyOrders.GetEnumerator();
                List<Order>.Enumerator sellEnum = sellOrders.GetEnumerator();
                buyEnum.MoveNext();
                sellEnum.MoveNext();

                if (buyEnum.Current.Price >= sellEnum.Current.Price)
                {
                    // Match the orders
                    // What price? bid? ask? midpoint?
                    double exePrice = sellEnum.Current.Price;
                    double exeQty = Math.Min(buyEnum.Current.Quantity, sellEnum.Current.Quantity);
                    buyEnum.Current.Execute(exePrice, exeQty);
                    sellEnum.Current.Execute(exePrice, exeQty);

                    filledOrders.Add(buyEnum.Current);
                    filledOrders.Add(sellEnum.Current);
                }
                else
                    return filledOrders;
            }
        }

        private List<Order> GetSortedOpenSellOrders(string symbol)
        {
            return GetSortedList(symbol, _sells, new OrderSorter(true));
        }

        private List<Order> GetSortedOpenBuyOrders(string symbol)
        {
            return GetSortedList(symbol, _buys, new OrderSorter(false));
        }

        private static List<Order> GetSortedList(string symbol, IEnumerable<Order> orders, IComparer<Order> orderSorter)
        {
            List<Order> sortedSellList = new List<Order>();

            foreach (Order order in orders)
            {
                if (order.isClosed() == false && order.Symbol == symbol)
                    sortedSellList.Add(order);
            }

            sortedSellList.Sort(orderSorter);

            return sortedSellList;
        }
    }

    public class OrderSorter : IComparer<Order>
    {
        private readonly int multiplier = 1;

        public OrderSorter(bool sortAscending)
        {
            if (sortAscending)
                multiplier = -1;
        }

        public int Compare(Order x, Order y)
        {
            if (x.Price == y.Price)
                return 0;

            if (x.Price > y.Price)
                return multiplier * -1;
            return multiplier * 1;
        }
    }
}