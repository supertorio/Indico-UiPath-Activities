using System.Runtime.Serialization;

namespace Indico.Custom.Enums
{
    public enum CollectionPermission
    {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "write")]
        Write
    }
}
