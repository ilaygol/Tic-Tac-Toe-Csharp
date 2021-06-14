using System;

namespace GameLogic
{
    public class Player
    {
        private readonly char r_Symbol;
        private readonly bool r_IsComputer;
        private int m_Score = 0;
        private string m_Name;

        public event Action<int> ScoreChanged;

        internal Player(char i_Symbol, bool i_IsComputer)
        {
            r_Symbol = i_Symbol;
            r_IsComputer = i_IsComputer;
            m_Score = 0;
        }

        internal char Symbol
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

            internal set
            {
                m_Score = value;
                OnScoreChanged(m_Score);
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            internal set
            {
                m_Name = value;
            }
        }

        protected virtual void OnScoreChanged(int i_Obj)
        {
            ScoreChanged?.Invoke(i_Obj);
        }
    }
}
