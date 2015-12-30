﻿using System.Runtime.Serialization;

namespace Elmah.Io.Apps.Manifest
{
    public enum VariableType
    {
        [EnumMember(Value = "text")]
        Text,
        [EnumMember(Value = "number")]
        Number,
        [EnumMember(Value = "checkbox")]
        Checkbox,
    }
}