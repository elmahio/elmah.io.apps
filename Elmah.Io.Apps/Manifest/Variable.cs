namespace Elmah.Io.Apps.Manifest
{
    public class Variable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public VariableType Type { get; set; }
        public bool Required { get; set; }
    }
}