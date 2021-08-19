using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.API
{
    public interface IWatchingService
    {
        void SwitchUser(string userId);
        Task<IContent> GetRandowContentAsync(IQueryParams query);
        void UpdateContent(IContent content);
        List<IContent> GetHistory();
        string GetCurrentUserId();
    }
}
