using System;

namespace B21_Ex02
{
    internal class Board
    {
        private readonly char[,] m_Board;

        public Board(int i_RowSize, int i_ColumnSize)
        {
            m_Board = new char[i_RowSize, i_ColumnSize];
            InitialBoard();
        }

        public Board(int i_SquareSize)
        {
            m_Board = new char[i_SquareSize, i_SquareSize];
            InitialBoard();
        }

        public int RowSize
        {
            get
            {
                return m_Board.Length / ColumnSize;
            }
        }

        public int ColumnSize
        {
            get
            {
                return m_Board.GetUpperBound(1) + 1;
            }
        }

        public char GetValue(ref Position i_Position)
        {
            return (char)m_Board.GetValue(i_Position.Row, i_Position.Column);
        }

        public void SetValue(ref Position i_Position, char i_Symbol)
        {
            m_Board[i_Position.Row, i_Position.Column] = i_Symbol;
        }

        public void InitialBoard()
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    m_Board[i, j] = ' ';
                }
            }
        }
    }
}
