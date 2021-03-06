﻿using System.Runtime.Serialization;

namespace Indico.Enums
{
    public enum ModelDomain
    {
        [EnumMember(Value = "standard")]
        Standard,
        [EnumMember(Value = "topics")]
        Topics,
        [EnumMember(Value = "sentiment")]
        Sentiment,
        [EnumMember(Value = "finance")]
        Finance,
        [EnumMember(Value = "ensemble")]
        Ensemble,
        [EnumMember(Value = "image_v2")]
        Image_V2,
        [EnumMember(Value = "image_v3")]
        Image_V3
    }
}
