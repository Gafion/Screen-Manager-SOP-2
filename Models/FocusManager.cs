namespace Screen_Manager_SOP_2
{
    internal class FocusManager
    {
        private readonly List<IFocusable> focusables;
        private int currentFocusIndex = -1;

        public FocusManager (IEnumerable<IFocusable> focusables)
        {
            InitializeFocus();
            this.focusables!.AddRange(focusables);
        }

        private void InitializeFocus()
        {
            if (focusables.Count != 0)
            {
                currentFocusIndex = 0;
                focusables[currentFocusIndex].Focus();
            }
        }

        public void MoveFocus(ConsoleKey key)
        {
            if (focusables.Count == 0) return;

            if (currentFocusIndex >= 0)
            {
                focusables[currentFocusIndex].Defocus();
            }

            if (key == ConsoleKey.Tab)
            {
                currentFocusIndex = (currentFocusIndex + 1) % focusables.Count;
            }

            focusables[currentFocusIndex].Focus(); 
        }

        public void HandleKeyPress(ConsoleKeyInfo keyInfo)
        {
            if (currentFocusIndex >= 0)
            {
                focusables[currentFocusIndex].HandleKeyPress(keyInfo);
            }
        }
    }
}
