namespace Elmah.Io.Apps.Manifest
{
    public class ChoiceVariable : VariableBase
    {
        public ChoiceVariable() : base(VariableType.Choice)
        {
        }

        public string Default { get; set; }

        public string[] Values { get; set; }
    }
}