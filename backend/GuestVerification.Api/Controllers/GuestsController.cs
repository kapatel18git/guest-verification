using Microsoft.AspNetCore.Mvc;
using GuestVerification.Core.DTOs;
using GuestVerification.Core.Services;

namespace GuestVerification.Api.Controllers
{
    [ApiController]
    [Route("api/guests")]
    public class GuestsController : ControllerBase
    {
        private readonly IVerificationService _verificationService;

        public GuestsController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        [HttpPost("verify")]
        public async Task<ActionResult<VerificationResponseDto>> VerifyGuest(VerificationRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.MobileNumber))
            {
                return BadRequest(new { message = "Mobile number is required" });
            }

            var result = await _verificationService.VerifyGuestAsync(request.MobileNumber);

            if (!result.IsVerified)
            {
                return Unauthorized(new { message = result.Message });
            }

            return Ok(result);
        }

        [HttpGet("validate/{mobileNumber}")]
        public async Task<ActionResult<bool>> ValidateMobileNumber(string mobileNumber)
        {
            if (string.IsNullOrWhiteSpace(mobileNumber))
            {
                return BadRequest(new { message = "Mobile number is required" });
            }

            var isValid = await _verificationService.ValidateMobileNumberAsync(mobileNumber);
            return Ok(new { isValid });
        }
    }
}
