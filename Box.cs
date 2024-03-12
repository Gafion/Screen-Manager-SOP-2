using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    internal class Box(int left, int top, int width, int height, ConsoleColor color = ConsoleColor.White) : Object(left, top, width, height)
    {
        public const char TopLeft = '┌';
        public const char TopRight = '┐';
        public const char BottomLeft = '└';
        public const char BottomRight = '┘';
        public const char Horizontal = '─';
        public const char Vertical = '│';
        public const char LeftMiddle = '├';
        public const char RightMiddle = '┤';
        public const char TopMiddle = '┬';
        public const char BottomMiddle = '┴';
        public const char Cross = '┼';
        public ConsoleColor Color { get; private set; } = color;
    }
}
