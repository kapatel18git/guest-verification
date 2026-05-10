namespace GuestVerification.Core.Entities
{
    public class VerificationLog
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public bool IsSuccessful { get; set; }
        public DateTime VerifiedAt { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }
}
