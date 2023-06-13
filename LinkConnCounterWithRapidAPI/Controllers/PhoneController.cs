using Microsoft.AspNetCore.Mvc;

namespace LinkConnCounterWithRapidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly PhoneNumberValidateService _phoneNumberValidateService;
        private readonly SmsService _smsService;
        public PhoneController(PhoneNumberValidateService PhoneNumberValidateService, SmsService smsService)
        {
            _phoneNumberValidateService = PhoneNumberValidateService;
            _smsService = smsService;
        }

        [HttpGet("PhoneNumberValidate")]
        public async Task<IActionResult> PhoneNumberValidate()
        {
            try
            {
                var phoneNumber=await _phoneNumberValidateService.ValidatePhoneNumber();
                return Ok(phoneNumber);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("SendSms")]
        public async Task<IActionResult> SendSms([FromForm] string phoneNumber, [FromForm] string message)
        {
            try
            {
                var response = await _smsService.SendSmsAsync(phoneNumber, message);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

