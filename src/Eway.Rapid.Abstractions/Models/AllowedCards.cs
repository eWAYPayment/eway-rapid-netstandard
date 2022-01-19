using System;

namespace Eway.Rapid.Abstractions.Models
{
    [Flags]
    public enum AllowedCards
    {
        None = 0x0,
        Visa = 0x1,
        Mastercard = 0x2,
        Amex = 0x4,
        Diners = 0x8,
        UnionPay = 0x10
    }
}
