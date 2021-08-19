using BingeWatching.API;
using System;
using System.Threading.Tasks;

namespace BingeWatching
{
    public class SwitchUserMenuStateHandler : IMenuStateHandler
    {
        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.SwitchUser;
        }

        public async Task Handle(IWatchingService watchingService)
        {
            watchingService.SwitchUser(GetUserName());
            await Task.CompletedTask;
        }
        private string GetUserName()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter user id and press enter");
                Console.WriteLine("-------------------");
                Console.WriteLine();
                Console.WriteLine("Enter your choice:");

                return Console.ReadLine();

            }

        }
    }
}