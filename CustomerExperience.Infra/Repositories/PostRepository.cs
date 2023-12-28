using CustomerExperience.Domain.PostAggregate;


namespace CustomerExperience.Infra.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {

        public PostRepository(AppDbContext context) : base(context) { }
    }
}
