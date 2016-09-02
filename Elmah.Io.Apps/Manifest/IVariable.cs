namespace Elmah.Io.Apps.Manifest
{
    public interface IVariable
    {
        VariableType Type { get; }
        string Key { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool Required { get; set; }
    }
}