using BingeWatching.API;
using BingeWatching.Core;
using BingeWatching.NetflixProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingeWatching
{
    public sealed class Menu
    {
        IWatchingService _watchingService;
        ILogger _logger;
        private readonly IList<IMenuStateHandler> _menuStateHandlers = new List<IMenuStateHandler>
        {
            new ContentMenuStateHandler(),
            new SwitchUserMenuStateHandler(),
            new HistoryMenuStateHandler(),
            new ExitMenuStateHandler()
        };
        public Menu()
        {
            IServiceFactory serviceFactory = new NetflixServiceFactory();
            _watchingService=serviceFactory.CreateWatchingService();
            _watchingService.SwitchUser("Guest");
            _logger = new Logger();

        }

        public async void Run()
        {
            while (true)
            {
                var menuState = GetMenuState();

                var handler = _menuStateHandlers.FirstOrDefault(h => h.CanHandle(menuState));
                if (handler == null)
                    throw new NotImplementedException();
                try
                {
                    await handler.Handle(_watchingService);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unexpected Error");
                    _logger.LogError("Unexpected error :", ex);
                }
            }
        }

        private MenuState GetMenuState()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Binge Watching menu");
                Console.WriteLine("-------------------");

                var allMenuStates = GetAllPossibleMenuStates();
                foreach (MenuState menuState in allMenuStates)
                {
                    Console.WriteLine($"Press {(char) menuState} for {menuState}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your choice:");

                var choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();
                var menuStateChoice = (MenuState) Enum.ToObject(typeof(MenuState), choice);
                if (allMenuStates.Contains(menuStateChoice))
                {
                    return menuStateChoice;
                }

                Console.WriteLine("Invalid Choice! - Please choose again");
            }
        }

        private MenuState[] GetAllPossibleMenuStates() =>
            (MenuState[]) Enum.GetValues(typeof(MenuState));
    }
}