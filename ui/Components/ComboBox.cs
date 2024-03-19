using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    internal class ComboBox : DrawableObject
    {

        public ComboBox(Position pos, Dimensions dim, List<string> options) : base(pos, dim)
        {
            Console.CursorVisible = false;
            int activeIndex = 0;

            ClearArea(pos, dim);
            Dimensions dropdownBorder = new(dim.Width, dim.Height * options.Count + Margins.BorderVerticalMarginDouble);
            _ = new Box(dropdownBorder, pos);

            for (int i = 0; i < options.Count; i++)
            {
                string text = options[i].PadRight(dim.Width - Margins.BorderHorizontalMarginDouble);
                if (i == activeIndex)
                {
                    _ = new Textfield(new Position(pos.Left + 1, pos.Top + 1 + i),dim, text, Alignment.Left, ConsoleColor.Black, ConsoleColor.White);
                }
                else
                {
                    _ = new Textfield(new Position(pos.Left + 1, pos.Top + 1 + i), dim, text, Alignment.Left);
                }
            }
        }

    }
}
