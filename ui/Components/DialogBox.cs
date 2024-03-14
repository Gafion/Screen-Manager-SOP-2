using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    internal class DialogBox : Box
    {
        public DialogBox(Dimensions dim, Position pos, Alignment? align) 
            : base(dim, pos)
        {
            _ = new Box(dim, pos);

            Dimensions TextfieldDimensions = new(dim);
            TextfieldDimensions.Width -= Margins.BorderHorizontalMargin;
            TextfieldDimensions.Height -= Margins.BorderHorizontalMargin;
            _ = new Textfield(new Position(pos.Left + Margins.BorderHorizontalMargin, pos.Top + Margins.BorderVerticalMargin), TextfieldDimensions, "Create New User", align);
        }
    }
}
