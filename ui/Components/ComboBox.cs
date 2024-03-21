namespace Screen_Manager_SOP_2
{
    internal class ComboBox : DrawableObject
    {

        public ComboBox(Position pos, Dimensions dim, List<string> options) : base(pos, dim)
        {
            Console.CursorVisible = false;
            int activeIndex = 0;

            ClearArea(pos, dim);
            Dimensions dropdownBorder = new(dim.Width, dim.Height * options.Count + Margins.BorderVerticalMarginDouble);
            _ = new Box(dropdownBorder, pos);

            for (int i = 0; i < options.Count; i++)
            {
                string text = options[i].PadRight(dim.Width - Margins.BorderHorizontalMarginDouble);
                if (i == activeIndex)
                {
                    _ = new Textfield(new Position(pos.Left + 1, pos.Top + 1 + i),dim, text, Alignment.Left, ConsoleColor.Black, ConsoleColor.White);
                }
                else
                {
                    _ = new Textfield(new Position(pos.Left + 1, pos.Top + 1 + i), dim, text, Alignment.Left);
                }
            }
        }

        public void Focus()
        {
            // Code to visually indicate the button is focused, e.g., change color.
        }

        public void Defocus()
        {
            // Code to revert visual indication of focus.
        }

        public void HandleKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                // Call the method associated with the button.
            }
        }

    }
}
