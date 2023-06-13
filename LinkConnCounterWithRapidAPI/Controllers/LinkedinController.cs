using LinkConnCounterWithRapidAPI.Models;
using LinkConnCounterWithRapidAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection.PortableExecutable;

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
