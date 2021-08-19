using BingeWatching.API;
using BingeWatching.Common;

namespace BingeWatching.NetflixProvider
{
    public class NetflixContentQueryParams : ContentQueryParams
    {
        private IQueryParams queryParams;

        public NetflixContentQueryParams(IQueryParams queryParams)
        {
            this.queryParams = queryParams;
        }

        public bool cache { get; set; }
        public ContentAvailability Availability { get; set; }
        public override string ToUri()
        {
            return $"nocache={!cache}&availability={Availability}&{queryParams.ToUri()}";
        }
    }
   
    public enum ContentAvailability
    {
        onAnySource
    }
}
