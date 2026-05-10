using AutoMapper;
using GuestVerification.Core.DTOs;
using GuestVerification.Core.Entities;
using GuestVerification.Data;

namespace GuestVerification.Core.Services
{
    public class WhitelistService : IWhitelistService
    {
        private readonly GuestVerificationDbContext _dbContext;
        private readonly IMapper _mapper;

        public WhitelistService(GuestVerificationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WhitelistEntryDto?> AddToWhitelistAsync(string mobileNumber)
        {
            var normalizedNumber = NormalizeMobileNumber(mobileNumber);

            var existing = _dbContext.WhitelistEntries
                .FirstOrDefault(w => w.MobileNumber == normalizedNumber);

            if (existing != null)
            {
                return null;
            }

            var entry = new GuestWhitelist
            {
                MobileNumber = normalizedNumber,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _dbContext.WhitelistEntries.Add(entry);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<WhitelistEntryDto>(entry);
        }

        public async Task<bool> RemoveFromWhitelistAsync(string mobileNumber)
        {
            var normalizedNumber = NormalizeMobileNumber(mobileNumber);

            var entry = _dbContext.WhitelistEntries
                .FirstOrDefault(w => w.MobileNumber == normalizedNumber);

            if (entry == null)
            {
                return false;
            }

            _dbContext.WhitelistEntries.Remove(entry);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<WhitelistEntryDto>> GetAllWhitelistEntriesAsync()
        {
            var entries = _dbContext.WhitelistEntries
                .Where(w => w.IsActive)
                .ToList();

            return _mapper.Map<List<WhitelistEntryDto>>(entries);
        }

        private string NormalizeMobileNumber(string mobileNumber)
        {
            return System.Text.RegularExpressions.Regex.Replace(mobileNumber, @"\D", "");
        }
    }
}
