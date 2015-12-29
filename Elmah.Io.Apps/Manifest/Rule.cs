namespace Elmah.Io.Apps.Manifest
{
    public class Rule
    {
        public string Title { get; set; }
        public string Query { get; set; }
        public IThen Then { get; set; }
    }
}