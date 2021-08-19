using BingeWatching.API;
using BingeWatching.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.ContentHandlers
{
    public abstract class BaseContentHandler : IContentStateHandler
    {
        private readonly IList<IQuestionHandler> _yesNoStateHandlers = new List<IQuestionHandler>
        {
            new YesWatchingStateHandler(),
            new NoWatchingStateHandler()
        };

        public abstract bool CanHandle(ContentState contentState);

        public async Task Handle(IWatchingService watchingService)
        {
            
            var query = GetQueryParams();
            var data = await watchingService.GetRandowContentAsync(query);
            if (data == null)
                Console.WriteLine("Service unavailable");
            else
            {
                Console.WriteLine($"You are now watching {data.title}");
                bool ranked = false;
                while (!ranked)
                {
                    var content = GetContentState();
                    var handler = _yesNoStateHandlers.FirstOrDefault(h => h.CanHandle(content));
                    if (handler == null)
                        throw new NotImplementedException();

                    if (handler.Handle(data))
                    {
                        watchingService.UpdateContent(data);
                        ranked = true;
                    }
                }
            }

        }
        private QUESTION GetContentState()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Did you finished");
                Console.WriteLine("-------------------");

                var allQuestionsStates = GetAllPossibleContentStates();
                foreach (QUESTION contentState in allQuestionsStates)
                {
                    Console.WriteLine($"Press {(char)contentState} for {contentState}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your choice:");

                var choice = char.ToUpperInvariant(Console.ReadKey().KeyChar);
                Console.WriteLine();
                var contentStateChoice = (QUESTION)Enum.ToObject(typeof(QUESTION), choice);
                if (allQuestionsStates.Contains(contentStateChoice))
                {
                    return contentStateChoice;
                }
                Console.WriteLine("Invalid Choice! - Please choose again");
            }
        }

            private QUESTION[] GetAllPossibleContentStates() =>
        (QUESTION[])Enum.GetValues(typeof(QUESTION));

        public abstract ContentQueryParams GetQueryParams();
    }
}
