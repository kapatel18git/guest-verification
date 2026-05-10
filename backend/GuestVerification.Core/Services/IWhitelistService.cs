using GuestVerification.Core.DTOs;

namespace GuestVerification.Core.Services
{
    public interface IWhitelistService
    {
        Task<WhitelistEntryDto?> AddToWhitelistAsync(string mobileNumber);
        Task<bool> RemoveFromWhitelistAsync(string mobileNumber);
        Task<List<WhitelistEntryDto>> GetAllWhitelistEntriesAsync();
    }
}
