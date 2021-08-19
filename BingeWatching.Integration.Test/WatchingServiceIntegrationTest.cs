using BingeWatching.API;
using BingeWatching.Common;
using BingeWatching.Core;
using BingeWatching.NetflixProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.Integration.Test
{
    [TestClass]
    public class WatchingServiceIntegrationTest
    {
        private IWatchingService _sut;
        private IContentService contentService;
        private WatchHistoryCacheService cacheService;
        [TestInitialize]
        public void Setup()
        {
            contentService = Substitute.For<IContentService>();
            cacheService = new WatchHistoryCacheService();
            _sut = new WatchingService(contentService, cacheService);
            _sut.SwitchUser("guest");
        }

        [TestMethod]
        public void GetRandowContentAsyncTestTwiceSameUser()
        {
            Content content1 = new Content
            {
                id = "1",
                title = "1"
            };
            Content content2 = new Content
            {
                id = "2",
                title = "2"
            };
            var query = new ContentQueryParams { ContentKind = ContentKind.both };
            contentService.GetRandowContentAsync(query).Returns(content1, content1, content2);
            var value = _sut.GetRandowContentAsync(query).Result;
            var value2 = _sut.GetRandowContentAsync(query).Result;
            Assert.AreNotEqual(value2.id, value.id);

        }
        [TestMethod]
        public void GetRandowContentAsyncTestTwiceDifferentUser()
        {
            Content content1 = new Content
            {
                id = "1",
                title = "1"
            };
            Content content2 = new Content
            {
                id = "2",
                title = "2"
            };
            var query = new ContentQueryParams { ContentKind = ContentKind.both };
            contentService.GetRandowContentAsync(query).Returns(content1, content1, content2);
            var value = _sut.GetRandowContentAsync(query).Result;
            _sut.SwitchUser("user2");
            var value2 = _sut.GetRandowContentAsync(query).Result;
            Assert.AreEqual(value2.id, value.id);

        }
    }
}
