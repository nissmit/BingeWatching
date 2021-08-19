using BingeWatching.API;
using BingeWatching.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.NetflixProvider
{
    public class NetflixServiceFactory : IServiceFactory
    {
        public IWatchingService CreateWatchingService()
        {
            return new WatchingService(new NetFlixService(new Logger()), new WatchHistoryCacheService());
        }
    }
}
