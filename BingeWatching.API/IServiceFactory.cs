using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.API
{
    public interface IServiceFactory
    {
        public IWatchingService CreateWatchingService();
    }
}
