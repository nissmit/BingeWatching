using BingeWatching.API;
using System.Threading.Tasks;

namespace BingeWatching
{
    public interface IMenuStateHandler
    {
        bool CanHandle(MenuState menuState);
        Task Handle(IWatchingService watchingService);
    }
    public interface IQuestionHandler
    {
        bool CanHandle(QUESTION menuState);
        bool Handle(IContent content);
    }
    public interface IContentStateHandler
    {
        bool CanHandle(ContentState contentState);
        Task Handle(IWatchingService contentFetcher);
    }
}