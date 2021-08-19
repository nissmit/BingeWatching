using BingeWatching.API;
using System;

namespace BingeWatching.Common
{
    public class Content:IContent
    {
        public string id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public double imdb_rating { get; set; }
        public double UserRanking { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Content);
        }

        public bool Equals(Content other)
        {
            return other != null &&
                   id == other.id &&
                   title == other.title;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, title);
        }

        public override string ToString()
        {
            return $"Title : {title} {Environment.NewLine}Overview : {overview} {Environment.NewLine}ImdbRanking : {imdb_rating} {Environment.NewLine}UserRanking : {UserRanking}";
        }

    }
}