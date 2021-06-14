namespace B21_Ex02
{
    internal class Player
    {
        private readonly char r_Symbol;
        private readonly bool r_IsComputer;
        private int m_Score = 0;

        public Player(char i_Symbol, bool i_IsComputer)
        {
            r_Symbol = i_Symbol;
            r_IsComputer = i_IsComputer;
            m_Score = 0;
        }

        public char Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public bool IsComputer
        {
            get
            {
                return r_IsComputer;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }
    }
}
