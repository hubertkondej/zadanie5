[ApiController]
[Route("api/trips")]
namespace Zadanie7.Controllers
{
    public class TripController : ControllerBase
    {
        private readonly ITripDbRepository _repository;

        public TripController(ITripDbRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips()
        {
            var trips = await _repository.GetTrips();
            var tripDTOs = trips.Select(t => new TripDTO
            {
                IdTrip = t.IdTrip,
                Name = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                Description = t.Description,
                MaxPeople = t.MaxPeople,
                ClientTrips = t.ClientTrips.Select(ct => new ClientTripDTO
                {
                    IdClient = ct.IdClient,
                    IdTrip = ct.IdTrip,
                    PaymentDate = ct.PaymentDate,
                    RegisteredAt = ct.RegisteredAt
                }).ToList()
            }).ToList();

            return Ok(tripDTOs);
        }

        [HttpPost("{idTrip}/clients")]
        public async Task<IActionResult> AddClientToTrip(int idTrip, [FromBody] AddTripToClientRequestDTO dto)
        {
            try
            {
                await _repository.AddClientToTrip(dto.IdClient, idTrip, dto.PaymentDate);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}