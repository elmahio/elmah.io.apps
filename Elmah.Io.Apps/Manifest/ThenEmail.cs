namespace Elmah.Io.Apps.Manifest
{
    public class ThenEmail : IThen
    {
        public ThenEmail(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
        public ThenType Type => ThenType.Email;
    }
}