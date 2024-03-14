using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    public class Dimensions
    {
        public int Width { get; set; } 
        public int Height { get; set; } 
        public static Dimensions Empty { get; } = new(0, 0);
        public Dimensions(int width, int heigth)
        {
            Width = Math.Max(0, width);
            Height = Math.Max(0, heigth);
        }
        public Dimensions(Dimensions dim)
        {
            this.Width = dim.Width;
            this.Height = dim.Height;
        }
    }
}