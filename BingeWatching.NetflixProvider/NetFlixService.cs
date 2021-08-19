
using System.Threading.Tasks;
using BingeWatching.API;
using BingeWatching.Common;
using System.Configuration;
using System.Net.Http;
using System.Text.Json;
using System;
using BingeWatching.Core;

namespace BingeWatching.NetflixProvider
{
    public class NetFlixService : IContentService
    {
        
        private readonly string _url;
        private readonly ILogger _logger;
        private readonly IHttpHelper _httpHelper;
        public NetFlixService(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            _url = ConfigurationManager.AppSettings["NetflixUrl"];
            _logger = logger;
            _httpHelper = new HttpHelper(_url);
        }


        public async Task<IContent> GetRandowContentAsync(IQueryParams queryParams)
        {
            //Add polly
            try
            {
                return await _httpHelper.StreamWithSystemTextJson(new NetflixContentQueryParams(queryParams));
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on fetching netflix", ex);
            }
            return null;
            
        }

       

    }
}
