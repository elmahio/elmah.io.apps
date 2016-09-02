namespace Elmah.Io.Apps.Manifest
{
    public class NumberVariable : VariableBase
    {
        public NumberVariable() : base(VariableType.Number)
        {
        }

        public int? Default { get; set; }

        public int? Example { get; set; }
    }
}