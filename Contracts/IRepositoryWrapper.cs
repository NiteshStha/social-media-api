using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IPostRepository Post { get; }
        ICommentRepository Comment { get; }

        Task Commit();
        void Save();
    }
}