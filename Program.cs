using System.Runtime.InteropServices;

namespace Screen_Manager_SOP_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Dimensions MainBoxDim = new(Console.WindowWidth, Console.WindowHeight);
            Box MainBox = new(
                    MainBoxDim,
                    new Position(0, 0));

            _ = new Textfield(
                    new Position(2, 1),
                    MainBoxDim,
                    "CRUDapp",
                    Alignment.Left,
                    ConsoleColor.Magenta);

            _ = new Button(
                    new Position(MainBox.Pos.Left + Console.WindowWidth - Margins.ButtonWidth - Margins.BorderHorizontalMargin, 
                                 MainBox.Pos.Top + Margins.BorderVerticalMargin),
                    new Dimensions(14, 3),
                    "New User",
                    Alignment.Center);


            List<string> titles = ["Dev", "DevOps", "UX", "Support", "CEO"];
            _ = new ComboBox(
                    new Position(20, 10),
                    new Dimensions(22, 3),
                    titles);

            /*_ = new DialogBox(
                    new Dimensions(
                        55, 
                        Math.Min(30, Console.WindowHeight)),
                    new Position(
                        (Console.WindowWidth - 55) / 2, 
                        (Console.WindowHeight - Math.Min(30, Console.WindowHeight)) / 2),
                    Alignment.Center);*/

            Console.ReadKey();  
        }
    }
}
