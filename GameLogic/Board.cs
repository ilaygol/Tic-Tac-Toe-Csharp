using System;

namespace GameLogic
{
    internal class Board
    {
        private readonly BoardCell[,] r_Board;

        public Board(int i_RowSize, int i_ColumnSize)
        {
            r_Board = new BoardCell[i_RowSize, i_ColumnSize];
            InitialBoard();
        }

        public Board(int i_SquareSize)
        {
            r_Board = new BoardCell[i_SquareSize, i_SquareSize];
            InitialBoard();
        }

        public int RowSize
        {
            get
            {
                return r_Board.Length / ColumnSize;
            }
        }

        public int ColumnSize
        {
            get
            {
                return r_Board.GetUpperBound(1) + 1;
            }
        }

        public char GetPositionSymbol(ref Position i_Position)
        {
            return r_Board[i_Position.Row, i_Position.Column].Symbol;
        }

        public void SetSymbol(ref Position i_Position, char i_Symbol)
        {
            r_Board[i_Position.Row, i_Position.Column].Symbol = i_Symbol;
        }

        public void InitialBoard()
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColumnSize; j++)
                {
                    r_Board[i, j] = new BoardCell(new Position(i, j));
                }
            }
        }
    }
}
