using NUnit.Framework;
using QuickFix;

namespace OrderMatchCSharp
{
    [TestFixture]
    public class OrderTests
    {
        private Order _order;

        [SetUp]
        public void SetUp()
        {
            _order = new Order("clientId", "GE", "owner", "target",
                               new Side(Side.BUY), new OrdType(OrdType.LIMIT), 12.50, 100);
        }

        #region Set Fields Tests

        [Test]
        public void SetClientID()
        {
            Assert.That(_order.ClientId, Is.EqualTo("clientId"));
        }

        [Test]
        public void SetSymbol()
        {
            Assert.That(_order.Symbol, Is.EqualTo("GE"));
        }

        [Test]
        public void SetOwner()
        {
            Assert.That(_order.Owner, Is.EqualTo("owner"));
        }

        [Test]
        public void SetTarget()
        {
            Assert.That(_order.Target, Is.EqualTo("target"));
        }

        [Test]
        public void SetSide()
        {
            Assert.That(_order.Side.getValue(), Is.EqualTo(Side.BUY));
        }
        
        [Test]
        public void SetOrdType()
        {
            Assert.That(_order.OrdType.getValue(), Is.EqualTo(OrdType.LIMIT));
        }

        [Test]
        public void SetPrice()
        {
            Assert.That(_order.Price, Is.EqualTo(12.50));
        }

        [Test]
        public void SetQuantity()
        {
            Assert.That(_order.Quantity, Is.EqualTo(100));
        }

        [Test]
        public void SetOpenQuantity()
        {
            Assert.That(_order.OpenQuantity, Is.EqualTo(100));
        }

        [Test]
        public void SetExecutedQuantity()
        {
            Assert.That(_order.ExecutedQuantity, Is.EqualTo(0));
        }

        [Test]
        public void SetAvgExecutedPrice()
        {
            Assert.That(_order.AvgExecutedPrice, Is.EqualTo(0.0));
        }

        [Test]
        public void SetLastExecutedPrice()
        {
            Assert.That(_order.LastExecutedPrice, Is.EqualTo(0.00));
        }

        [Test]
        public void SetLastExecutedQuantity()
        {
            Assert.That(_order.LastExecutedQuantity, Is.EqualTo(0));
        }

        #endregion Set Fields Tests

        #region Zero Executions Tests

        [Test]
        public void IsFilledAfterNoExecutions()
        {
            Assert.That(_order.IsFilled(), Is.EqualTo(false));
        }

        [Test]
        public void IsClosedAfterNoExecutionsPositiveQuantity()
        {
            Assert.That(_order.isClosed(), Is.EqualTo(false));
        }

        #endregion Zero Executions Tests

        #region One Execution

        [Test]
        public void AvgExePriceAfterOneExecution()
        {
            ExecuteOneOrder();

            Assert.That(_order.AvgExecutedPrice, Is.EqualTo(12.50));
        }

        [Test]
        public void OpenQtyFieldsAfterOneExecution()
        {
            ExecuteOneOrder();

            Assert.That(_order.OpenQuantity, Is.EqualTo(50));
        }

        [Test]
        public void ExeQtyfterOneExecution()
        {
            ExecuteOneOrder();

            Assert.That(_order.ExecutedQuantity, Is.EqualTo(50));
        }

        [Test]
        public void LastExePriceAfterOneExecution()
        {
            ExecuteOneOrder();

            Assert.That(_order.LastExecutedPrice, Is.EqualTo(12.50));
        }

        [Test]
        public void LastExeQtyAfterOneExecution()
        {
            ExecuteOneOrder();

            Assert.That(_order.LastExecutedQuantity, Is.EqualTo(50));
        }

        [Test]
        public void AvgExePriceAfterTwoExecutions()
        {
            ExecuteOneOrder();
            _order.Execute(12.00, 50);

            Assert.That(_order.AvgExecutedPrice, Is.EqualTo(12.25));
        }

        #endregion One Execution

        private void ExecuteOneOrder()
        {
            _order.Execute(12.50, 50);
        }

        [Test]
        public void ToStringForOneOrder()
        {
            Assert.That(_order.ToString(), Is.EqualTo("ID: clientId, OWNER: owner, PRICE: 12.50, QUANTITY: 100") );
        }
    }
}