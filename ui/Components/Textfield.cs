namespace Screen_Manager_SOP_2
{
    internal class Textfield : DrawableObject
    {
        private readonly string text = "";

        public string Text { get { return text; } }
        public Textfield(Position pos, Dimensions dim, string text, Alignment? align, ConsoleColor FG = ConsoleColor.White, ConsoleColor BG = ConsoleColor.Black) 
            : base(pos, dim)
        {
            this.text = text;

            int aligned = Aligner.Align(this.text, align, dim.Width);
            InsertAt(new Position(pos.Left + aligned, pos.Top), this.text, FG, BG);
        }
    }
}
