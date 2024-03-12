namespace Screen_Manager_SOP_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Box MainBorder = new(0, 0, Console.WindowWidth, Console.WindowHeight, "CRUDapp");
            MainBorder.DrawBox();

            Console.ReadKey();  
        }
    }
}
