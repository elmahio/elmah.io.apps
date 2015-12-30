using System.Runtime.Serialization;

namespace Elmah.Io.Apps.Manifest
{
    public enum VariableType
    {
        [EnumMember(Value = "text")]
        Text,
        // Not yet supported:
        //[EnumMember(Value = "number")]
        //Number,
        //[EnumMember(Value = "checkbox")]
        //Checkbox,
    }
}