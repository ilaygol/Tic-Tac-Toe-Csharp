namespace GameLogic
{
    public struct Position
    {
        private int m_Row;
        private int m_Column;
        private char m_Symbol;

        public Position(int i_Row, int i_Column)
        {
            m_Row = i_Row;
            m_Column = i_Column;
            m_Symbol = ' ';
        }

        public Position(int i_Row, int i_Column, char i_Symbol)
        {
            m_Row = i_Row;
            m_Column = i_Column;
            m_Symbol = i_Symbol;
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

        public char Symbol
        {
            get
            {
                return m_Symbol;
            }
            set
            {
                m_Symbol = value;
            }
        }

        public void SetLocation(int i_Row, int i_Column)
        {
            Row = i_Row;
            Column = i_Column;
        }

        public void SetValues(int i_Row, int i_Column, char i_Symbol)
        {
            Row = i_Row;
            Column = i_Column;
            Symbol = i_Symbol;
        }

        public void DecValues()
        {
            Row--;
            Column--;
        }
    }
}
