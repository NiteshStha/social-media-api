using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repositoryContext;
        private IUserRepository _user;
        private IPostRepository _post;
        private ICommentRepository _comment;

        public IUserRepository User => _user ??= new UserRepository(_repositoryContext);

        public IPostRepository Post => _post ??= new PostRepository(_repositoryContext);

        public ICommentRepository Comment => _comment ??= new CommentRepository(_repositoryContext);

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task Commit()
        {
            await _repositoryContext.SaveChangesAsync();
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}