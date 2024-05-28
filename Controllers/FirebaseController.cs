using Microsoft.AspNetCore.Mvc;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Threading.Tasks;
using Firebase.Database;

namespace FirebaseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirebaseController : ControllerBase
    {
        private readonly IFirebaseClient _firebaseClient;

        public FirebaseController(IFirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            FirebaseResponse response = await _firebaseClient.GetAsync("your-node/" + id);
            var data = response.ResultAs<object>(); // Cambia 'object' por tu modelo de datos
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object data) // Cambia 'object' por tu modelo de datos
        {
            PushResponse response = await _firebaseClient.PushAsync("your-node", data);
            return Ok(response.Result);
        }

        // Otros métodos (PUT, DELETE, etc.) pueden ser agregados aquí
    }
}
