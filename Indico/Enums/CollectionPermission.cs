using System.Runtime.Serialization;

namespace Indico.Enums
{
    public enum CollectionPermission
    {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "write")]
        Write
    }
}
