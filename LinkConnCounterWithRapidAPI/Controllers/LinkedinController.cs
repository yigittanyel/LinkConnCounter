using Microsoft.AspNetCore.Mvc;

namespace LinkConnCounterWithRapidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkedinController : ControllerBase
    {
        private readonly LinkedinService _linkedinService;

        public LinkedinController(LinkedinService linkedinService)
        {
            _linkedinService = linkedinService;
        }

        [HttpGet("GetLinkedinConnections")]
        public async Task<IActionResult> GetLinkedinConnections()
        {
            try
            {
                var getConnections = await _linkedinService.GetLinkedinConnections();
                return Ok(getConnections);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
