using System.Reflection.Emit;
using System.Text;
using static Screen_Manager_SOP_2.Actions;

namespace Screen_Manager_SOP_2
{
    internal class CaptureInputField : DrawableObject, IHasDimensions, IHasPosition, IFocusable
    {
        private bool isFocused = false;
        private readonly StringBuilder buffer = new();
        public Position FieldPos { get; private set; }
        public Dimensions FieldDim { get; private set; }
        public int? MaxLength { get; set; }
        private readonly Actions.ButtonAction ButtonAction;
        public CaptureInputField(Position pos, Dimensions dim, Actions.ButtonAction action, int? maxLength = null) 
            : base(pos, dim)
        {
            this.FieldPos = pos;
            this.FieldDim = dim;
            this.ButtonAction = action;
            this.MaxLength = maxLength;

            CaptureInput();

        }

        public void CaptureInput()
        {
            if (!isFocused) return;

            Console.SetCursorPosition(FieldPos.Left, FieldPos.Top);
            Console.CursorVisible = true;
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true); 
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && buffer.Length > 0)
                {
                    buffer.Remove(buffer.Length - 1, 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    if (!MaxLength.HasValue || buffer.Length < MaxLength.Value)
                    {
                        buffer.Append(keyInfo.KeyChar);
                        Console.Write(keyInfo.KeyChar);
                    }
                }
            } while (true);
        }

        public string GetInput()
        {
            return buffer.ToString();
        }

        public void ClearInput()
        {
            buffer.Clear();
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
            ButtonAction?.Invoke();
        }
    }
}
