using Contracts;
using Entities;
using Entities.models;

namespace Repository
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}