namespace Elmah.Io.Apps.Manifest
{
    public class PasswordVariable : VariableBase
    {
        public PasswordVariable() : base(VariableType.Password)
        {
        }

        public string Example { get; set; }
    }
}
