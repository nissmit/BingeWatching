using BingeWatching.API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BingeWatching
{
    public class HistoryMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.History;
        }

        public async Task Handle(IWatchingService watchingService)
        {
            var userName = watchingService.GetCurrentUserId();
            var history = watchingService.GetHistory();
            PrintHistory(history, userName);
            await Task.CompletedTask;
        }

        private void PrintHistory(List<IContent> history, string userName)
        {
            Console.WriteLine();
            Console.WriteLine($"Binge Watching history for user {userName}");
            Console.WriteLine("-------------------");
            foreach (IContent content in history)
            {
                Console.WriteLine(content.ToString());
                Console.WriteLine("-------------------");
            }
        }
    }
}