
using BingeWatching.API;
using BingeWatching.Common;
using BingeWatching.ContentHandlers;
using System;
using System.Net;
using System.Net.Http.Headers;

namespace BingeWatching
{
    internal class AnyContentStateHandler : BaseContentHandler
    {
        public override bool CanHandle(ContentState contentState)
        {
            return contentState == ContentState.Any;
        }

      

        public override ContentQueryParams GetQueryParams()
        {
            return new ContentQueryParams
            {
                ContentKind = ContentKind.both
            };
        }

       
    }
}