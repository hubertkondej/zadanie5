
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Zadanie7.Repositories
{
    public class ClientDbRepository : IClientDbRepository
    {
        private readonly ApbdContext _context;

        public ClientDbRepository(ApbdContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.Include(c => c.ClientTrips).ToListAsync();
        }

        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<bool> ClientExists(int id)
        {
            return await _context.Clients.AnyAsync(c => c.IdClient == id);
        }

        public async Task AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null || client.ClientTrips.Any()) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }

 }
