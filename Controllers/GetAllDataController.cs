// GetAllDataController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ChileanSlagApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetAllDataController : ControllerBase // Cambia el nombre de la clase a GetAllDataController
    {
        private readonly GetAllData _getAllData;
        private readonly ILogger<GetAllDataController> _logger;

        public GetAllDataController(GetAllData getAllData, ILogger<GetAllDataController> logger)
        {
            _getAllData = getAllData;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            try
            {
                _logger.LogInformation("Attempting to retrieve all data.");
                var data = await _getAllData.GetAllAsync();
                _logger.LogInformation("Data retrieved successfully.");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all data.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
