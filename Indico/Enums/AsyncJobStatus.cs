using System.Runtime.Serialization;

namespace Indico.Enums
{
    public enum AsyncJobStatus
    {
        [EnumMember(Value = "SUCCESS")]
        Success,
        [EnumMember(Value = "FAILURE")]
        Failure,
        [EnumMember(Value = "REVOKED")]
        Revoked,
        [EnumMember(Value = "PENDING")]
        Pending
    }
}
