using GuestVerification.Core.DTOs;
using GuestVerification.Data;

namespace GuestVerification.Core.Services
{
    public class VerificationService : IVerificationService
    {
        private readonly GuestVerificationDbContext _dbContext;

        public VerificationService(GuestVerificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VerificationResponseDto> VerifyGuestAsync(string mobileNumber)
        {
            var normalizedNumber = NormalizeMobileNumber(mobileNumber);

            var whitelist = _dbContext.WhitelistEntries
                .FirstOrDefault(w => w.MobileNumber == normalizedNumber && w.IsActive);

            if (whitelist == null)
            {
                return new VerificationResponseDto
                {
                    IsVerified = false,
                    Message = "Mobile number not found in guest list",
                    MobileNumber = normalizedNumber
                };
            }

            // Log verification
            var log = new Entities.VerificationLog
            {
                MobileNumber = normalizedNumber,
                IsSuccessful = true,
                VerifiedAt = DateTime.UtcNow
            };

            _dbContext.VerificationLogs.Add(log);
            await _dbContext.SaveChangesAsync();

            return new VerificationResponseDto
            {
                IsVerified = true,
                Message = "Guest verified successfully",
                MobileNumber = normalizedNumber,
                VerifiedAt = DateTime.UtcNow
            };
        }

        public async Task<bool> ValidateMobileNumberAsync(string mobileNumber)
        {
            var normalizedNumber = NormalizeMobileNumber(mobileNumber);
            return await Task.FromResult(
                _dbContext.WhitelistEntries.Any(w => w.MobileNumber == normalizedNumber && w.IsActive)
            );
        }

        private string NormalizeMobileNumber(string mobileNumber)
        {
            return System.Text.RegularExpressions.Regex.Replace(mobileNumber, @"\D", "");
        }
    }
}
