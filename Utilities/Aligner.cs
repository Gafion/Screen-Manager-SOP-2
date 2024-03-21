namespace Screen_Manager_SOP_2
{
    class Aligner
    {
        internal static int Align(string text, Alignment? aligment, int MaxWidth) 
        {
            if (text == null)
            {
                return 0;
            }
            if (text.Length > MaxWidth)
            {
                return 0;
            }

            int diff = MaxWidth - text.Length;

            return aligment switch
            {
                Alignment.Right => diff,
                Alignment.Center => diff /= 2,
                _ => 0,
            };
        }
    }
}
