using System.Collections.Generic;
using System.Threading.Tasks;
namespace Zadanie7.Interfaces
{
    public interface IClientDbRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task<bool> ClientExists(int id);
        Task AddClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}