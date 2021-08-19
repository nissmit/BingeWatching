using BingeWatching.API;
using BingeWatching.Common;
using BingeWatching.ContentHandlers;
using System;

namespace BingeWatching
{
    internal class MovieContentStateHandler : BaseContentHandler
    {
        public override bool CanHandle(ContentState contentState)
        {
            return contentState == ContentState.Movie;
        }

        public override ContentQueryParams GetQueryParams()
        {
            return new ContentQueryParams
            {
                ContentKind = ContentKind.Movie
            };
        }
    }
}