namespace Elmah.Io.Apps.Manifest
{
    public class Variable
    {
        public Variable()
        {
            Type = VariableType.Text;
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Example { get; set; }
        public string Description { get; set; }
        public VariableType Type { get; set; }
        public bool Required { get; set; }
    }
}