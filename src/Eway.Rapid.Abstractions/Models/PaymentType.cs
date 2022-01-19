namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// The Payment type merchant use for the request.
    /// The corresponding payment detail to this PaymentType must be provided.
    ///   CreditCard  -->  CardDetails
    ///   CardPresence --> PosDetails
    ///   PayPal --> Customer.GlobalPayerId  must be Paypal token customer Id  
    ///   ClickToPay --> WalletDetails.Id
    ///   SecurePay  --> WalletDetails.Token
    ///   ApplePay  --> WalletDetails.Token
    ///   GooglePay --> WalletDetails.Token
    /// </summary>
    public enum PaymentType
    {
        None,  //Allow None for tokenpayment
        CreditCard,
        CardPresence,
        PayPal,
        ClickToPay,   //SRC
        ApplePay,
        GooglePay,
        SecurePay,    // This is the encryptedCardDetails or OneTimeCode payment which will be merged to Wallet as discussion.
    }
}
