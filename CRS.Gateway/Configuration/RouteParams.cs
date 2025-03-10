namespace CRS.Gateway.Configuration
{    public class RouteParams
    {
        public string DownstreamPathTemplate { get; set; } = "";
        public string DownstreamScheme { get; set; } = "";
        public string DownstreamHostAndPorts { get; set; } = "";
        public string UpstreamPathTemplate { get; set; } = "";
        public List<string> UpstreamHttpMethods { get; set; } = [];
        public List<string> UpstreamSchemes { get; set; } = [];
    }
}

