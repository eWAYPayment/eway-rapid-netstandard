namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// What action will be taken when creating a transaction
    /// </summary>
    /// <value>What action will be taken when creating a transaction</value>
    public enum Method
    {
        ProcessPayment = 1,
        CreateTokenCustomer,
        UpdateTokenCustomer,
        TokenPayment,
        Refund,
        Authorise,
        Scheduled
    }
}
