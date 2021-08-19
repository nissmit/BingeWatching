namespace BingeWatching.API
{
    public interface IContent
    {
        string id { get; set; }
        string title { get; set; }
        string overview { get; set; }
        double imdb_rating { get; set; }
        double UserRanking { get; set; }
    }
}