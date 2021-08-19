using System;

namespace BingeWatching
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Netflix Binge watching service.");
            new Menu().Run();
            Console.WriteLine("Goodbye, see you again soon.");
        }
    }
}