using Microsoft.AspNetCore.Mvc;
using GuestVerification.Core.DTOs;
using GuestVerification.Core.Services;

namespace GuestVerification.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IWhitelistService _whitelistService;

        public AdminController(IWhitelistService whitelistService)
        {
            _whitelistService = whitelistService;
        }

        [HttpPost("whitelist")]
        public async Task<ActionResult<WhitelistEntryDto>> AddToWhitelist(WhitelistRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.MobileNumber))
            {
                return BadRequest(new { message = "Mobile number is required" });
            }

            var result = await _whitelistService.AddToWhitelistAsync(request.MobileNumber);

            if (result == null)
            {
                return BadRequest(new { message = "Mobile number already exists in whitelist" });
            }

            return Created(string.Empty, result);
        }

        [HttpDelete("whitelist/{mobileNumber}")]
        public async Task<ActionResult> RemoveFromWhitelist(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                return BadRequest(new { message = "Mobile number is required" });
            }

            var result = await _whitelistService.RemoveFromWhitelistAsync(mobileNumber);

            if (!result)
            {
                return NotFound(new { message = "Mobile number not found in whitelist" });
            }

            return NoContent();
        }

        [HttpGet("whitelist")]
        public async Task<ActionResult<List<WhitelistEntryDto>>> GetWhitelist()
        {
            var entries = await _whitelistService.GetAllWhitelistEntriesAsync();
            return Ok(entries);
        }
    }
}
