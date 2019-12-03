using System.Runtime.Serialization;

namespace Elmah.Io.Apps.Manifest
{
    public enum VariableType
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "choice")]
        Choice,
        [EnumMember(Value = "number")]
        Number,
        [EnumMember(Value = "bool")]
        Bool,
        [EnumMember(Value = "password")]
        Password,
        [EnumMember(Value = "hidden")]
        Hidden,
    }
}