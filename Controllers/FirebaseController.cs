using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChileanSlagApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly GetAllData _getAllData;
        private readonly ILogger<DataController> _logger;

        public DataController(GetAllData getAllData, ILogger<DataController> logger)
        {
            _getAllData = getAllData;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Received request to get all data.");
                var data = await _getAllData.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all data.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
