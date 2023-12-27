using CustomerExperience.Domain.Shared;


namespace CustomerExperience.Domain.CategoryAggregate
{
    public class PostInteraction: BaseEntity
    {
        public InteractionType Type { get; private set; }
        public DateTime Timestamp { get; private set; }
        public int CustomerId { get; private set; }
        public int PostId { get; private set; }
        public Post? Post { get; private set; }

        private PostInteraction() { }

        internal PostInteraction(int customerId, InteractionType type, DateTime timestamp, int postId, Post? post)
        {
            CustomerId = customerId;
            Type = type;
            Timestamp = timestamp;
            PostId = postId;
            Post = post;
        }
    }
}
