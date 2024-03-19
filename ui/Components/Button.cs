using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Screen_Manager_SOP_2
{
    internal class Button : DrawableObject, IHasPosition, IHasDimensions
    {
        public Button(Position pos, Dimensions dim, string label, Alignment align = Alignment.Center) 
            : base(pos, dim)
        {
            _ = new Box(this.Dim, this.Pos);

            Dimensions TextfieldDimensions = new(dim);
            TextfieldDimensions.Width -= Margins.BorderHorizontalMarginDouble;
            TextfieldDimensions.Height -= Margins.BorderHorizontalMarginDouble;
            _ = new Textfield(new Position(this.Pos.Left + 1, this.Pos.Top + 1), TextfieldDimensions, label, align);
        }
    }
}
