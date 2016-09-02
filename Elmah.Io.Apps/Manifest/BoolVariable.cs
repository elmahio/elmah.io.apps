namespace Elmah.Io.Apps.Manifest
{
    public class BoolVariable : VariableBase
    {
        public BoolVariable() : base(VariableType.Bool)
        {
        }

        public bool? Default { get; set; }
    }
}