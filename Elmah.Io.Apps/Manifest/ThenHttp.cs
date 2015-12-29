using System;

namespace Elmah.Io.Apps.Manifest
{
    public class ThenHttp : IThen
    {
        public ThenHttp(Uri url)
        {
            Url = url;
            Method = "GET";
        }

        public Uri Url { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string Body { get; set; }
        public ThenType Type { get { return ThenType.Http; } }
    }
}