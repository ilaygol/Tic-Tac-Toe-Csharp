using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class BoardCell
    {
        private readonly Position r_Position;
        private char m_Symbol = ' ';

        public event Action<BoardCell> SymbolChanged; 

        internal BoardCell(Position i_Position)
        {
            r_Position = i_Position;
            Symbol = ' ';
        }

        public Position CellPosition
        {
            get
            {
                return r_Position;
            }
        }

        public char Symbol
        {
            get
            {
                return m_Symbol;
            }
            internal set
            {
                m_Symbol = value;
                OnSymbolChanged(this);
            }
        }

        protected virtual void OnSymbolChanged(BoardCell i_Obj)
        {
            SymbolChanged?.Invoke(i_Obj);
        }
    }
}
