namespace GameLogic
{
    public struct Position
    {
        private int m_Row;
        private int m_Column;

        public Position(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
        }

        public int Row
        {
            get
            {
                return m_Row;
            }
            set
            {
                m_Row = value;
            }
        }

        public int Column
        {
            get
            {
                return m_Column;
            }
            set
            {
                m_Column = value;
            }
        }

        public void SetValues(int i_Row, int i_Column)
        {
            Row = i_Row;
            Column = i_Column;
        }

        public void DecValues()
        {
            Row--;
            Column--;
        }
    }
}
