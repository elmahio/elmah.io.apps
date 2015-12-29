using System.Runtime.Serialization;

namespace Elmah.Io.Apps.Manifest
{
    public enum ThenType
    {
        [EnumMember(Value = "ignore")]
        Ignore,
        [EnumMember(Value = "hide")]
        Hide,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "http")]
        Http,
    }
}