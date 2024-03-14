using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    public class Parent
    {
        public Position Pos { get; set; }
        public Dimensions Dim { get; set; }
        public static Parent Empty { get; } = new(new Position(0, 0), new Dimensions(0, 0));
        public Parent(Position pos, Dimensions dim)
        {
            Pos = pos;
            Dim = dim;
        }
        public Parent(Parent par)
        {
            this.Pos = par.Pos;
            this.Dim = par.Dim;
        }
    }
}
