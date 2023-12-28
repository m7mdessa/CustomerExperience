using CustomerExperience.Packages;

namespace CustomerExperience.Domain.PostAggregate
{
    public class Post: AggregateRootEntity
    {
        #region Members
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishDate { get; private set; } = DateTime.Now;

        private readonly List<PostInteraction> _postInteractions = new();
        public virtual IReadOnlyCollection<PostInteraction> PostInteractions => _postInteractions;
        #endregion

        #region Constructors
        private Post() { }
        public Post(string title, string content)
        {
            Title = title;
            Content = content;
        }

        #endregion

        #region Internal Methods

        #region Post Methods
        public void UpdatePost(int id, string? title, string? content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public void DeletePost(int id)
        {
            var deletePost = _postInteractions?.SingleOrDefault(s => s.Id == id);
            _postInteractions?.Remove(deletePost);
        }

        #endregion

        #region Post Interaction Methods

        internal void Interact(int customerId, InteractionType type, int postId)
        {
            var postInteraction = new PostInteraction(customerId, type, postId);
            _postInteractions.Add(postInteraction);
        }

        internal void UpdateInteract(int id ,int customerId, InteractionType type, int postId)
        {
            var postById = _postInteractions.FirstOrDefault(x => x.Id == postId);
            postById.UpdatePostInteraction(id,customerId,type,postId);
        }

        internal void DeleteInteract(int postId)
        {
            var getPostInteractionById = _postInteractions?.FirstOrDefault(x => x.Id == postId);
            _postInteractions.Remove(getPostInteractionById);
        }
        #endregion

        #endregion
    }
}
