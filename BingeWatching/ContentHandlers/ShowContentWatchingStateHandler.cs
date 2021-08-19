using BingeWatching.API;
using BingeWatching.Common;
using BingeWatching.ContentHandlers;
using System;
using System.Collections.Generic;

namespace BingeWatching
{

    internal class ShowContentWatchingStateHandler : BaseContentHandler
    {
       
        public override bool CanHandle(ContentState contentState)
        {
            return contentState == ContentState.Show;
        }

        public override ContentQueryParams GetQueryParams()
        {
            return new ContentQueryParams
            {
                ContentKind = ContentKind.Show
            };
        }
    }
}