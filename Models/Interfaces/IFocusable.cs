namespace Screen_Manager_SOP_2
{
    internal interface IFocusable
    {
        void Focus();
        void Defocus();
        void HandleKeyPress(ConsoleKeyInfo keyInfo);
    }
}
