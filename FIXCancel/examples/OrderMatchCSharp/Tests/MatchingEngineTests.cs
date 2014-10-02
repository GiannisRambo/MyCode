using NUnit.Framework;
using QuickFix;

namespace OrderMatchCSharp
{
    [TestFixture]
    public class MatchingEngineTests
    {
        private readonly IMatchingEngineView _matchingEngine = new MatchingEngine();

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void AddOneNewOrder()
        {
            const string id = "101";
            _matchingEngine.AddNewOrder(
                new Order(id, "GE", "owner", "ORDERMATCH", 
                          new Side(Side.SELL), new OrdType(OrdType.LIMIT), 12.50, 200)
                );

            //bool orderFound = false;
            //foreach(Order order in _matchingEngine.GetBuyOrders("GE"))
            //    if (order.ClientId == id)
            //        orderFound = true;

            //Assert.True(orderFound);
        }

        //[Test]
        //public void AddTwoBuyOrdersForGE()
        //{
        //    const string id1 = "101";
        //    _matchingEngine.AddNewOrder(
        //        new Order(id1, "GE", "owner", "ORDERMATCH",
        //                  new Side(Side.SELL), new OrdType(OrdType.LIMIT), 12.50, 200)
        //        );

        //    Assert.True(HelperDoesOrderExist(id1, "GE"));

        //    const string id2 = "102";
        //    _matchingEngine.AddNewOrder(
        //        new Order(id2, "GE", "owner", "ORDERMATCH",
        //                  new Side(Side.BUY), new OrdType(OrdType.LIMIT), 12.50, 100)
        //        );

        //    Assert.True(HelperDoesOrderExist(id2, "GE"));
        //}

        //[Test]
        //public void AddOneGEOrderAndOneIBMOrder()
        //{
        //    const string id1 = "101";
        //    _matchingEngine.AddNewOrder(
        //        new Order(id1, "GE", "owner", "ORDERMATCH",
        //                  new Side(Side.SELL), new OrdType(OrdType.LIMIT), 12.50, 200)
        //        );

        //    Assert.True(HelperDoesOrderExist(id1, "GE"));

        //    const string id2 = "102";
        //    _matchingEngine.AddNewOrder(
        //        new Order(id2, "IBM", "owner", "ORDERMATCH",
        //                  new Side(Side.BUY), new OrdType(OrdType.LIMIT), 12.50, 100)
        //        );

        //    Assert.True(HelperDoesOrderExist(id2, "IBM"));
            
        //}

        //private bool HelperDoesOrderExist(string id, string symbol)
        //{
        //    bool orderFound = false;
        //    foreach (Order order in _matchingEngine.GetBuyOrders(symbol))
        //        if (order.ClientId == id)
        //            orderFound = true;
        //    return orderFound;
        //}
    }
}