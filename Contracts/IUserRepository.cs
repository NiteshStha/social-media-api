using System.Threading.Tasks;
using Entities.models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> Authenticate(string username, string password);
    }
}