namespace Elmah.Io.Apps.Manifest
{
    public class TextVariable : VariableBase
    {
        public TextVariable() : base(VariableType.Text)
        {
        }

        public string Default { get; set; }

        public string Example { get; set; }
    }
}