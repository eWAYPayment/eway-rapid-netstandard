namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Product information for an account
    /// </summary>
    public class AccountProductDetails
    {
        public string ProductDescription { get; set; }
        public int? ProductAverageOrderSize { get; set; }
        public int? ProductAverageDaysPaidInAdvance { get; set; }
    }
}
