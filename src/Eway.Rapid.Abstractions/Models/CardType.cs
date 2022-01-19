using System.Runtime.Serialization;


namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// The card type used in the tender
    /// </summary>
    /// <value>The card type used in the tender</value>
    public enum CardType
    {
        /// <summary>
        /// Enum MC for "MC"
        /// </summary>
        [EnumMember(Value = "MC")]
        MC = 1,

        /// <summary>
        /// Enum VISA for "VISA"
        /// </summary>
        [EnumMember(Value = "VISA")]
        VISA = 2,

        /// <summary>
        /// Enum DEBIT for "DEBIT"
        /// </summary>
        [EnumMember(Value = "DEBIT")]
        DEBIT = 3,

        /// <summary>
        /// Enum AMEX for "AMEX"
        /// </summary>
        [EnumMember(Value = "AMEX")]
        AMEX = 4,

        /// <summary>
        /// Enum DINERS for "DINERS"
        /// </summary>
        [EnumMember(Value = "DINERS")]
        DINERS = 5
    }
}
