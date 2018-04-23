using System.Collections.Generic;

namespace SeriesService.Models
{
    public class Image
    {
        public string showImage { get; set; }
    }

    public class NextEpisode
    {
        public object channel { get; set; }
        public string channelLogo { get; set; }
        public object date { get; set; }
        public string html { get; set; }
        public string url { get; set; }
    }

    public class Season
    {
        public string slug { get; set; }
    }

    public class SeriesServiceRequest
    {
        public string country { get; set; }
        public string description { get; set; }
        public bool drm { get; set; }
        public int episodeCount { get; set; }
        public string genre { get; set; }
        public Image image { get; set; }
        public string language { get; set; }
        public NextEpisode nextEpisode { get; set; }
        public string primaryColour { get; set; }
        public List<Season> seasons { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public string tvChannel { get; set; }
    }

    public class SeriesServiceRootRequest
    {
        public List<SeriesServiceRequest> SeriesService { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public int totalRecords { get; set; }
    }


    public class SeriesServiceResponse
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
    }

    public class SeriesServiceRootResponse
    {
        public List<SeriesServiceResponse> response { get; set; }
    }
}