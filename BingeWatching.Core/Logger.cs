using BingeWatching.API;
using System;

namespace BingeWatching.Core
{
    public class Logger : ILogger
    {
        public void LogError(string message, Exception ex)
        {
            Console.WriteLine($"{message} {ex}");
        }

        public void LogError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
