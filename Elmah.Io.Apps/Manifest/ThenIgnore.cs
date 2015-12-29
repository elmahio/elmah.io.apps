namespace Elmah.Io.Apps.Manifest
{
    public class ThenIgnore : IThen
    {
        public ThenType Type { get { return ThenType.Ignore; } }
    }
}