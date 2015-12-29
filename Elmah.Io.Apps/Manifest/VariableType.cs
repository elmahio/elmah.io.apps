using System.Runtime.Serialization;

namespace Elmah.Io.Apps.Manifest
{
    public enum VariableType
    {
        [EnumMember(Value = "string")]
        String,
        [EnumMember(Value = "integer")]
        Integer,
        [EnumMember(Value = "boolean")]
        Boolean,
    }
}