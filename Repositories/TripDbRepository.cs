using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Zadanie7.Repositories
{
    public class TripDbRepository : ITripDbRepository
    {
        private readonly ApbdContext _context;

        public TripDbRepository(ApbdContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTrips()
        {
            return await _context.Trips.Include(t => t.ClientTrips).OrderByDescending(t => t.StartDate).ToListAsync();
        }

        public async Task<Trip> GetTrip(int id)
        {
            return await _context.Trips.FindAsync(id);
        }

        public async Task<bool> TripExists(int id)
        {
            return await _context.Trips.AnyAsync(t => t.IdTrip == id);
        }

        public async Task AddClientToTrip(int clientId, int tripId, DateTime? paymentDate)
        {
            if (!await ClientExists(clientId) || !await TripExists(tripId))
            {
                throw new Exception("Client or Trip not found");
            }

            var clientTrip = new ClientTrip
            {
                IdClient = clientId,
                IdTrip = tripId,
                PaymentDate = paymentDate,
                RegisteredAt = DateTime.Now
            };

            await _context.ClientTrips.AddAsync(clientTrip);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> ClientExists(int id)
        {
            return await _context.Clients.AnyAsync(c => c.IdClient == id);
        }
    }
}