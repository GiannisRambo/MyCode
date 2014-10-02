namespace OrderMatchCSharp
{
    class IDGenerator
    {
        private long m_orderID;
        private long m_executionID;

        public IDGenerator()
        {
            m_orderID = 0;
            m_executionID = 0;
        }

        public string genOrderID()
        {
            m_orderID++;
            return m_orderID.ToString();
        }

        public string genExecutionID()
        {
            m_executionID++;
            return m_executionID.ToString();
        }
    }
}