using BingeWatching.API;
using System;
using System.Threading.Tasks;

namespace BingeWatching
{
    public class ExitMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.Exit;
        }

        public async Task Handle(IWatchingService watchingService)
        {
            Console.WriteLine("Au revoir, Shoshana!");
            await Task.CompletedTask;
            Environment.Exit(0);
        }

    }
}