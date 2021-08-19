using System.Threading.Tasks;

namespace BingeWatching.API
{
    public interface IContentService
    {
        Task<IContent> GetRandowContentAsync(IQueryParams query);
    }
}