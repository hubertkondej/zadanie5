using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Zadanie7.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientDbRepository _repository;

        public ClientController(IClientDbRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            return Ok(await _repository.GetClients());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _repository.GetClient(id);
            if (client == null || client.ClientTrips.Any())
            {
                return BadRequest("Nie znaleziono klineta.");
            }

            var result = await _repository.DeleteClient(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}