using System.Collections.Generic;
using System.Threading.Tasks;
namespace Zadanie7.Interfaces

{
    public interface ITripDbRepository
    {
        Task<IEnumerable<Trip>> GetTrips();
        Task<Trip> GetTrip(int id);
        Task<bool> TripExists(int id);
        Task AddClientToTrip(int clientId, int tripId, DateTime? paymentDate);
    }
}