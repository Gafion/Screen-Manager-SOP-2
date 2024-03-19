using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    class Borders
    {
        internal static char Get(BorderPart part)
        {
            return part switch
            {
                BorderPart.TopLeft => '┌',
                BorderPart.TopRight => '┐',
                BorderPart.BottomLeft => '└',
                BorderPart.BottomRight => '┘',
                BorderPart.Horizontal => '─',
                BorderPart.Vertical => '│',
                BorderPart.Left => '├',
                BorderPart.Right => '┤',
                BorderPart.TopMiddle => '┬',
                BorderPart.BottomMiddle => '┴',
                BorderPart.Cross => '┼',
                BorderPart.DownArrow => '˅',
        _ => throw new NotImplementedException()
            };
        }
    }
}
