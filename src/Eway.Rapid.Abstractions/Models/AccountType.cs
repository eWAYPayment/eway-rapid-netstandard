using System.Runtime.Serialization;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// The account type used for the transaction
    /// </summary>
    /// <value>The account type used for the transaction</value>
    public enum AccountType
    {
        /// <summary>
        /// Enum CREDIT for "CREDIT"
        /// </summary>
        [EnumMember(Value = "CREDIT")]
        CREDIT = 1,

        /// <summary>
        /// Enum SAVINGS for "SAVINGS"
        /// </summary>
        [EnumMember(Value = "SAVINGS")]
        SAVINGS = 2,

        /// <summary>
        /// Enum CHEQUE for "CHEQUE"
        /// </summary>
        [EnumMember(Value = "CHEQUE")]
        CHEQUE = 3,

        /// <summary>
        /// Enum UNKNOWN for "UNKNOWN"
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        UNKNOWN = 4
    }
}
