using BingeWatching.API;
using BingeWatching.Common;
using BingeWatching.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace BingeWatching.Test.Unit
{
    [TestClass]
    public class WatchingServiceTest
    {
        private WatchingService _sut;
        private IContentService contentService;
        private IWatchHistoryCacheService cacheService;
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
            cacheService.ContainsValue(content1).Returns(true);
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
                id = "1",
                title = "2"
            };
            var query = new ContentQueryParams { ContentKind = ContentKind.both };
            contentService.GetRandowContentAsync(query).Returns(content1, content1, content2);
            var value = _sut.GetRandowContentAsync(query).Result;
            cacheService.ContainsValue(content1).Returns(false);
            var value2 = _sut.GetRandowContentAsync(query).Result;
            Assert.AreEqual(value2.id, value.id);

        }

        [TestInitialize]
        public void Setup()
        {
            contentService = Substitute.For<IContentService>();
            cacheService= Substitute.For<IWatchHistoryCacheService>();
            _sut = new WatchingService(contentService, cacheService);
        }
    }
}
