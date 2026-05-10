namespace GuestVerification.Core.Entities
{
    public class GuestWhitelist
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public string? Notes { get; set; }
    }
}
