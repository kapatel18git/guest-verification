namespace GuestVerification.Core.DTOs
{
    public class WhitelistEntryDto
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
