namespace Screen_Manager_SOP_2
{
    internal class ComboBox : DrawableObject, IHasPosition, IHasDimensions, IFocusable
    {
        private bool isFocused = false;
        public event EventHandler? RequestFocusChange;
        public ComboBox(Position pos, Dimensions dim, List<string> options) 
            : base(pos, dim)
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
                    _ = new Textfield(new Position(pos.Left + Margins.BorderHorizontalMarginSingle, pos.Top + Margins.BorderVerticalMarginSingle + i),
                        dim, 
                        text, 
                        Alignment.Left, 
                        ConsoleColor.Black, 
                        ConsoleColor.White);
                }
                else
                {
                    _ = new Textfield(new Position(pos.Left + Margins.BorderHorizontalMarginSingle, pos.Top + Margins.BorderVerticalMarginSingle + i), 
                        dim, 
                        text, 
                        Alignment.Left);
                }
            }
        }

        public void Focus()
        {
            isFocused = true;
        }

        public void Defocus()
        {
            isFocused = false;
        }

        public void HandleKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Tab)
            {
                RequestFocusChangeHandler();
            }
        }
        private void RequestFocusChangeHandler()
        {
            RequestFocusChange?.Invoke(this, EventArgs.Empty);
        }

    }
}
