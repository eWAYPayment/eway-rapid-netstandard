namespace Eway.Rapid.Abstractions.Models
{
    public enum PaymentType
    {
        None = 0,
        CreditCard = 1,
        PayPal = 2,
        MasterPass = 4,
        VisaCheckout = 8,
        AmexExpressCheckout = 16,
        ApplePay = 32,
        DirectDebit = 64,
        UnionPay = 128,
        GooglePay = 256,
        ClickToPay = 512,
        SecurePay = 1024
    }
}
