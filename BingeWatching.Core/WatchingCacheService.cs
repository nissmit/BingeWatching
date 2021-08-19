using BingeWatching.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.Core
{
    public class WatchHistoryCacheService:CacheService<string, IContent>,IWatchHistoryCacheService
    {
    }
}
