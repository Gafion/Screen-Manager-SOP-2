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
            int activeIndex = 0;

            ClearArea(pos, dim);
            Dimensions dropdownBorder = new(dim.Width, dim.Height * options.Count + Margins.BorderVerticalMargin);
            _ = new Box(dropdownBorder, pos);

            for (int i = 0; i < options.Count; i++)
            {
                string text = options[i].PadRight(dim.Width - Margins.BorderHorizontalMargin);
                if (i == activeIndex)
                {
                    _ = new Textfield(new Position(pos.Left + 1, pos.Top + 1),dim, text, Alignment.Left, ConsoleColor.Black, ConsoleColor.White);
                }
                else
                {
                    _ = new Textfield(new Position(pos.Left + 1, pos.Top + 1), dim, text, Alignment.Left);
                }
            }

            
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        activeIndex = (activeIndex - 1 + options.Count) % options.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        activeIndex = (activeIndex + 1) % options.Count;
                        break;
                }
            } while (key != ConsoleKey.Enter);
            
        }

    }
}
