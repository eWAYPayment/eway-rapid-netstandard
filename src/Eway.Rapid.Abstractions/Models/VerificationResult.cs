namespace Eway.Rapid.Abstractions.Models
{
    public class VerificationResult
    {
        public VerificationStatus CVN { get; set; }

        public VerificationStatus Address { get; set; }

        public VerificationStatus Email { get; set; }

        public VerificationStatus Mobile { get; set; }

        public VerificationStatus Phone { get; set; }
    }
}
