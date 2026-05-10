namespace GuestVerification.Core.DTOs
{
    public class VerificationResponseDto
    {
        public bool IsVerified { get; set; }
        public string Message { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public DateTime VerifiedAt { get; set; }
    }
}
