using BingeWatching.API;
using System;

namespace BingeWatching
{
    internal class YesWatchingStateHandler : IQuestionHandler
    {
        public bool CanHandle(QUESTION menuState)
        {
            return menuState == QUESTION.Yes;
        }

        public bool Handle(IContent content)
        {
            var rate = GetContentRate();
            content.UserRanking = rate;
            return true;
        }

        private int GetContentRate()
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("Please rank the content (0-10) and press enter");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Enter your choice:");

                var choice = Console.ReadLine();
                int resul;
                if (int.TryParse(choice, out resul) && resul >= 0 && resul <= 10)
                    return resul;
    
                Console.WriteLine();
            }
          
        }
    }
}