namespace Elmah.Io.Apps.Manifest
{
    public class BasicAuthentication : IAuthentication
    {
        public AuthenticationType Type => AuthenticationType.Basic;

        public string Username { get; set; }

        public string Password { get; set; }
    }
}