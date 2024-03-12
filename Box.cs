using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    internal class Box(int left, int top, int width, int height, string title, ConsoleColor color = ConsoleColor.White) : Object(left, top, width, height)
    {
        public ConsoleColor Color { get; private set; } = color;
        public string Title { get; private set; } = title;

        public void DrawBox()
        {
            ClearArea(Left, Top, Width, Height);
            InsertAt(Left, Top, $"{Borders.TopLeft}{new string(Borders.Horizontal, Width - 2)}{Borders.TopRight}", Color);

            for (int i = 1; i < Height - 1; i++)
            {
                InsertAt(Left, Top + i, Borders.Vertical.ToString(), Color);
                InsertAt(Left + Width - 1, Top + i, Borders.Vertical.ToString(), Color);
            }

            // InsertAt(Left + 2, Top + 1, Title, Color);
            InsertAt(Left, Top + Height - 1, $"{Borders.BottomLeft}{new string(Borders.Horizontal, Width - 2)}{Borders.BottomRight}", Color);
        }
    }
}
