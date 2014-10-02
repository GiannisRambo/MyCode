using System;
using QuickFix;

namespace OrderMatchCSharp
{
    public class Order
    {
        public Order(string clientId, string symbol, string owner, string target,
            QuickFix.Side side, OrdType type, double price, double quantity)
        {
            ClientId = clientId;
            Symbol = symbol;
            Owner = owner;
            Target = target;
            Side = side;
            OrdType = type;
            Price = price;
            Quantity = quantity;

            OpenQuantity = quantity;
            ExecutedQuantity = 0;
            AvgExecutedPrice = 0.0;
            LastExecutedPrice = 0.0;
            LastExecutedQuantity = 0;
        }

        public string ClientId { get; private set; }
        public string Symbol { get; private set; }
        public string Owner { get; private set; }
        public string Target { get; private set; }
        public QuickFix.Side Side { get; private set; }
        public OrdType OrdType { get; private set; }
        public double Price { get; private set; }
        public double Quantity { get; private set; }

        public double OpenQuantity { get; private set; }
        public double ExecutedQuantity { get; private set; }
        public double AvgExecutedPrice { get; private set; }
        public double LastExecutedPrice { get; private set; }
        public double LastExecutedQuantity { get; private set; }

        public bool IsFilled()
        {
            return Quantity == ExecutedQuantity;
        }

        public bool isClosed()
        {
            return OpenQuantity == 0;
        }

        public void Execute(double price, double quantity)
        {
            AvgExecutedPrice =
                ((quantity*price) + (AvgExecutedPrice*ExecutedQuantity))
                /(quantity + ExecutedQuantity);

            OpenQuantity -= quantity;
            ExecutedQuantity += quantity;
            LastExecutedPrice = price;
            LastExecutedQuantity = quantity;
        }

        public void Cancel()
        {
            OpenQuantity = 0;
        }

        public override string ToString()
        {
            return "ID: " + ClientId + ", OWNER: " + Owner +
                   ", PRICE: " + String.Format("{0:0.00}", Price) +", QUANTITY: " + Quantity;
        }
    }
}