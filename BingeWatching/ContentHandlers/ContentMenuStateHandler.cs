using BingeWatching.API;
using BingeWatching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingeWatching
{
    public class ContentMenuStateHandler : IMenuStateHandler
    {

        public ContentMenuStateHandler()
        {
            
        }
        private readonly IList<IContentStateHandler> _contentStateHandlers = new List<IContentStateHandler>
        {
            new ShowContentWatchingStateHandler(),
            new MovieContentStateHandler(),
            new AnyContentStateHandler()
        };
       

        public bool CanHandle(MenuState menuState)
        {
            return menuState == MenuState.Content;
        }

        public async Task Handle(IWatchingService watchingService)
        {
            var content = GetContentState();
            var handler = _contentStateHandlers.FirstOrDefault(h => h.CanHandle(content));
            if (handler == null)
                throw new NotImplementedException();

            await handler.Handle(watchingService);
        }

        private ContentState GetContentState()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please tell us what kind of content you wish to watch");
                Console.WriteLine("-------------------");

                var allContentStates = GetAllPossibleContentStates();
                foreach (ContentState contentState in allContentStates)
                {
                    Console.WriteLine($"Press {(char)contentState} for {contentState}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your choice:");

                var choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();
                var contentStateChoice = (ContentState)Enum.ToObject(typeof(ContentState), choice);
                if (allContentStates.Contains(contentStateChoice))
                {
                    return contentStateChoice;
                }
                Console.WriteLine("Invalid Choice! - Please choose again");
            }
        }

        private ContentState[] GetAllPossibleContentStates() =>
        (ContentState[])Enum.GetValues(typeof(ContentState));

    }
}