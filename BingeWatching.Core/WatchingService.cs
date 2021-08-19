using BingeWatching.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.Core
{
    public class WatchingService: IWatchingService
    {
        IWatchHistoryCacheService _cacheService;
        IContentService _contentService;
        public WatchingService(IContentService contentService, IWatchHistoryCacheService cacheService)
        {
            if (contentService == null) throw new ArgumentNullException(nameof(contentService));
            if (cacheService == null) throw new ArgumentNullException(nameof(cacheService));
            _contentService = contentService;
            _cacheService = cacheService;
        }
        public void SwitchUser(string userId)
        {
            if (_cacheService.ContainsKey(userId))
                _cacheService.CurrentKey=userId;
            else
            {
                _cacheService.AddKey(userId);
                _cacheService.CurrentKey = userId;
            }
        }
        public async Task<IContent> GetRandowContentAsync(IQueryParams query)
        {
            IContent data = await _contentService.GetRandowContentAsync(query);
            if (data == null)
                return null;
            while(_cacheService.ContainsValue(data))
                data = await _contentService.GetRandowContentAsync(query);
            _cacheService.AddValue(data);
            return data;
        }
        public void UpdateContent(IContent content)
        {
            _cacheService.UpdateValue(content);
        }
        public List<IContent> GetHistory()
        {
            return _cacheService.GetValues();
        }
        public string GetCurrentUserId()
        {
            return _cacheService.CurrentKey;
        }
    }
}
