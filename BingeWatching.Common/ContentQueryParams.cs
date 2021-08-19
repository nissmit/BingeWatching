using BingeWatching.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingeWatching.Common
{
    public class ContentQueryParams : IQueryParams
    {
        public ContentKind ContentKind { get; set; }
        public virtual string ToUri()
        {
            return $"content_kind={ContentKind}";
        }
    }
    public enum ContentKind
    {
        both,
        Movie,
        Show
    }
}
