namespace Elmah.Io.Apps.Manifest
{
    public class ThenHttp : IThen
    {
        public ThenHttp(string url)
        {
            Url = url;
            Method = "GET";
        }

        public string Url { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }
        public ThenType Type { get { return ThenType.Http; } }
    }
}