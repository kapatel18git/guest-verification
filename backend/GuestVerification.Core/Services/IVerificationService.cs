using GuestVerification.Core.DTOs;

namespace GuestVerification.Core.Services
{
    public interface IVerificationService
    {
        Task<VerificationResponseDto> VerifyGuestAsync(string mobileNumber);
        Task<bool> ValidateMobileNumberAsync(string mobileNumber);
    }
}
