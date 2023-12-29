using CustomerExperience.Domain.PostAggregate;
using Microsoft.EntityFrameworkCore;


namespace CustomerExperience.Infra.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {

        public PostRepository(AppDbContext context) : base(context) { }

      
    }
}
