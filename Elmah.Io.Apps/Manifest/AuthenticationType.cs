using System.Runtime.Serialization;

namespace Elmah.Io.Apps.Manifest
{
    public enum AuthenticationType
    {
        [EnumMember(Value = "basic")]
        Basic,
        [EnumMember(Value = "bearer")]
        Bearer
    }
}