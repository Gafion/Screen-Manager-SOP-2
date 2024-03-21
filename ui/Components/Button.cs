namespace Screen_Manager_SOP_2
{
    internal class Button : DrawableObject, IHasPosition, IHasDimensions, IFocusable
    {
        private bool isFocused = false;
        private readonly string label;
        private readonly Alignment alignment;
        private readonly Actions.ButtonAction ButtonAction;

        public Button(Position pos, Dimensions dim, string label, Actions.ButtonAction action, Alignment align = Alignment.Center) 
            : base(pos, dim)
        {
            this.ButtonAction = action;
            this.label = label;
            this.alignment = align;
            DrawButton();
        }
        public void Focus()
        {
            isFocused = true;
            DrawButton();
        }

        public void Defocus()
        {
            isFocused = false;
            DrawButton();
        }

        public void HandleKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                ButtonAction?.Invoke();
            }
        }

        public void DrawButton()
        {
            ConsoleColor fgColor = isFocused ? ConsoleColor.Red : ConsoleColor.White;

            _ = new Box(this.Dim, this.Pos);

            Dimensions TextfieldDimensions = new(this.Dim);
            TextfieldDimensions.Width -= Margins.BorderHorizontalMarginDouble;
            TextfieldDimensions.Height -= Margins.BorderHorizontalMarginDouble;
            _ = new Textfield(
                new Position(   this.Pos.Left + Margins.BorderHorizontalMarginSingle, 
                                this.Pos.Top + Margins.BorderVerticalMarginSingle), 
                TextfieldDimensions, label, alignment, fgColor);
        }
    }
}
