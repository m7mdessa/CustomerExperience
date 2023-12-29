using CustomerExperience.Domain.PostAggregate;
using Microsoft.EntityFrameworkCore;


namespace CustomerExperience.Infra.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {

        public PostRepository(AppDbContext context) : base(context) { }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.Include(p => p.PostInteractions).ToListAsync();
        }
    }
}
