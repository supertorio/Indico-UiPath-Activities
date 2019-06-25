using System.Runtime.Serialization;

namespace Indico.Custom.Enums
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
        [EnumMember(Value = "elmo")]
        Elmo,
        [EnumMember(Value = "ensemble")]
        Ensemble,
        [EnumMember(Value = "image_v2")]
        Image_V2,
        [EnumMember(Value = "image_v3")]
        Image_V3,
        [EnumMember(Value = "image_v4")]
        Image_V4
    }
}