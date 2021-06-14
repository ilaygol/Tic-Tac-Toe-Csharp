using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class GameManager
    {
        private readonly Board r_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private int m_MovesCount;
        private readonly Random r_RandomComputerChoice;

        public GameManager(int i_BoardSize, bool i_IsVersusComputer)
        {
            const bool v_IsComputer = true;
            r_Board = new Board(i_BoardSize);
            m_Player1 = new Player('X', !v_IsComputer);
            m_Player2 = new Player('O', i_IsVersusComputer);
            m_CurrentPlayer = m_Player1;
            m_MovesCount = 0;
            r_RandomComputerChoice = new Random();
        }
        
        internal Board GameBoard
        {
            get
            {
                return r_Board;
            }
        }

        public int BoardSize
        {
            get
            {
                return GameBoard.RowSize;
            }
        }

        internal Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            set
            {
                m_CurrentPlayer = value;
            }
        }

        internal Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        internal Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public bool IsGoodPositionChoice(Position i_Position)
        {
            bool isGood = true;
            if (GameBoard.GetPositionSymbol(ref i_Position) != ' ')
            {
                isGood = false;
            }

            return isGood;
        }

        //public bool SetPositionOnBoard(Position i_Position)
        //{
        //    bool isGoodPosition = IsGoodPositionChoice(i_Position);
        //    if(isGoodPosition == true)
        //    {
        //        GameBoard.SetValue(ref i_Position, m_CurrentPlayer.Symbol);
        //        m_MovesCount++;
        //    }
        //    return isGoodPosition;
        //}

        public Position? GetComputerPositionChoice()
        {
            List<Position> positionList = GetAvailablePositions();
            Position? resPosition = null;
            if(positionList.Count != 0)
            {
                int randomIndex = r_RandomComputerChoice.Next(positionList.Count);
                resPosition = positionList[randomIndex];
            }
            return resPosition;
        }

        public List<Position> GetAvailablePositions()
        {
            List<Position> positionList = new List<Position>();
            Position currentPosition = new Position();
            for(int i = 0; i < GameBoard.RowSize; i++)
            {
                for(int j = 0; j < GameBoard.ColumnSize; j++)
                {
                    currentPosition.SetLocation(i, j);
                    if(IsGoodPositionChoice(currentPosition))
                    {
                        positionList.Add(currentPosition);
                    }
                }
            }
            return positionList;
        }

        public bool IsGameEnded(Position i_LastPosition, out bool o_IsTie)
        {
            bool isRow = isFullRow(i_LastPosition);
            bool isColumn = isFullColumn(i_LastPosition);
            bool isSlant = isFullSlant();
            bool isReachMaxMoves = m_MovesCount == GameBoard.RowSize * GameBoard.ColumnSize;
            o_IsTie = isReachMaxMoves;
            return isRow || isColumn || isSlant;
        }

        //public void PlayerWins(Player i_Winner)
        //{
        //    i_Winner.Score++;
        //}

        public void SwitchCurrentPlayer()
        {
            if(CurrentPlayer.Equals(Player1))
            {
                CurrentPlayer = Player2;
            }
            else
            {
                CurrentPlayer = Player1;
            }
        }

        private bool isFullRow(Position i_LastPosition)
        {
            bool isFull = true;
            char symbol = m_CurrentPlayer.Symbol;
            Position tempPosition = new Position(i_LastPosition.Row, 0);
            for(int i = 0; i < GameBoard.ColumnSize; i++)
            {
                tempPosition.Column = i;
                if(GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }

        private bool isFullColumn(Position i_LastPosition)
        {
            bool isFull = true;
            char symbol = m_CurrentPlayer.Symbol;
            Position tempPosition = new Position(0, i_LastPosition.Column);
            for (int i = 0; i < GameBoard.RowSize; i++)
            {
                tempPosition.Row = i;
                if (GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }

        private bool isFullSlant()
        {
            bool isFullMain = true;
            bool isFullSecond = true;
            char symbol = m_CurrentPlayer.Symbol;
            Position tempPosition = new Position();
            //check main slant
            for(int i = 0; i < GameBoard.RowSize; i++)
            {
                tempPosition.SetLocation(i, i);
                if (GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFullMain = false;
                    break;
                }
            }

            //check second slant
            for(int i = GameBoard.RowSize - 1; i >= 0; i--)
            {
                tempPosition.SetLocation(i, GameBoard.RowSize - 1 - i);
                if (GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFullSecond = false;
                    break;
                }
            }
            return isFullMain || isFullSecond;
        }

        public void ResetGameToNewRound()
        {
            CurrentPlayer = Player1;
            GameBoard.InitialBoard();
            m_MovesCount = 0;
        }
    }
}
