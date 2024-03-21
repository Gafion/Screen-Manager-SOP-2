namespace Screen_Manager_SOP_2
{
    public abstract class DrawableObject(Position? pos, Dimensions dim) : Creator, IHasPosition, IHasDimensions
    {
        public Position Pos { get; set; } = pos ?? new Position(0, 0);
        public Dimensions Dim { get; set; } = dim;
    }


}
