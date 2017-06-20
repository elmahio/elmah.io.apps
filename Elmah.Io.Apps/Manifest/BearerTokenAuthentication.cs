namespace Elmah.Io.Apps.Manifest
{
    public class BearerTokenAuthentication : IAuthentication
    {
        public AuthenticationType Type => AuthenticationType.Bearer;

        public string Token { get; set; }
    }
}