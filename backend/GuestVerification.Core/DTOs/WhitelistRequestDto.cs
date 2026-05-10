namespace GuestVerification.Core.DTOs
{
    public class WhitelistRequestDto
    {
        public string MobileNumber { get; set; } = string.Empty;
        public string? Notes { get; set; }
    }
}
