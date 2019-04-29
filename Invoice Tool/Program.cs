using System;

namespace Invoice_Tool
{
    class Program
    {
        private static void SetConsoleColor(ConsoleColor background, ConsoleColor foreground)
        {
            Console.BackgroundColor = background;
            Console.Clear();
            Console.ForegroundColor = foreground;
        }

        static void Main(string[] args)
        {
            SetConsoleColor(Config.BACKGROUND, Config.FOREGROUND);
            do { var invoice = new Invoice(); } while (true);
        }
    }
}