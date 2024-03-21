namespace Screen_Manager_SOP_2
{
    public class Position
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public static Position Empty { get; } = new(0, 0);
        public Position(int left, int top)
        {
            Left = Math.Max(0, left);
            Top = Math.Max(0, top);
        }
        public Position(Position position)
        {
            this.Left = position.Left;
            this.Top = position.Top;
        }
    }
}
