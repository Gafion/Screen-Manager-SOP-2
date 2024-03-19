using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Manager_SOP_2
{
    internal class CaptureInputField(Position pos, Dimensions dim, int? maxLength = null) : DrawableObject(pos, dim)
    {
        private readonly StringBuilder buffer = new();
        public Position FieldPos { get; private set; } = pos;
        public Dimensions FieldDim { get; private set; } = dim;
        public int? MaxLength { get; set; } = maxLength;

        public void CaptureInput()
        {
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
    }
}
