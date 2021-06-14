using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace UserInterface
{
    internal class CellButton : Button
    {
        private readonly BoardCell r_BoardCell;
        
        public CellButton(BoardCell i_BoardCell)
        {
            r_BoardCell = i_BoardCell;
            r_BoardCell.SymbolChanged += r_BoardCell_SymbolChanged;
            //this.Location = new System.Drawing.Point(13, 13);
            //this.Name = "Button00";
            this.Size = new System.Drawing.Size(50, 50);
            this.UseVisualStyleBackColor = true;
        }

        private void r_BoardCell_SymbolChanged(BoardCell i_BoardCell)
        {
            this.Text = i_BoardCell.Symbol.ToString();
        }
    }
}
