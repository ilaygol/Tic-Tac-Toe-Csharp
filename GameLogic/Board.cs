using System;

namespace GameLogic
{
    internal class Board
    {
        private readonly Position[,] r_PositionsBoard;

        public Board(int i_RowSize, int i_ColumnSize)
        {
            r_PositionsBoard = new Position[i_RowSize, i_ColumnSize];
            InitialBoard();
        }

        public Board(int i_SquareSize)
        {
            r_PositionsBoard = new Position[i_SquareSize, i_SquareSize];
            InitialBoard();
        }

        public int RowSize
        {
            get
            {
                return r_PositionsBoard.Length / ColumnSize;
            }
        }

        public int ColumnSize
        {
            get
            {
                return r_PositionsBoard.GetUpperBound(1) + 1;
            }
        }

        public char GetPositionSymbol(ref Position i_Position)
        {
            return (char)r_PositionsBoard[i_Position.Row, i_Position.Column].Symbol;
        }

        public void SetSymbol(ref Position i_Position, char i_Symbol)
        {
            r_PositionsBoard[i_Position.Row, i_Position.Column].Symbol = i_Symbol;
        }

        public void InitialBoard()
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    r_PositionsBoard[i, j].SetValues(i, j, ' ');
                }
            }
        }
    }
}
