namespace Elmah.Io.Apps.Manifest
{
    public class BearerTokenAuthentication : IAuthentication
    {
        public AuthenticationType Type
        {
            get
            {
                return AuthenticationType.Bearer;
            }
        }

        public string Token { get; set; }
    }
}