using BingeWatching.API;
using System.Configuration;
using System.Threading.Tasks;

namespace BingeWatching
{
    internal class NoWatchingStateHandler : IQuestionHandler
    {
        int delay;
        public NoWatchingStateHandler()
        {
            if (!int.TryParse(ConfigurationManager.AppSettings["DelayInMs"], out delay))
                delay = 10000;
        }
        public bool CanHandle(QUESTION menuState)
        {
            return menuState == QUESTION.No;
        }

        public bool Handle(IContent content)
        {
            Task.Delay(delay).Wait();
            return false;
        }
    }
}