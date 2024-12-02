namespace InputHandlingNamespace
{
    class InputHandling
    {
        public static string StringInput(string placeholder)
        {
            Console.Write(placeholder);

            return Console.ReadLine() ?? "";
        }
        public static int IntInput(string placeholder)
        {
            Console.Write(placeholder);

            return Convert.ToInt16(Console.ReadLine());
        }
    }
}