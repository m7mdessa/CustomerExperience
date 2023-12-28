using CustomerExperience.Packages;

namespace CustomerExperience.Domain.PostAggregate
{

    public class Post: AggregateRootEntity
    {
        #region Members
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishDate { get; private set; } 

        private readonly List<PostInteraction> _postInteractions = new();
        public virtual IReadOnlyCollection<PostInteraction> PostInteractions => _postInteractions;
        #endregion

        #region Constructors
        private Post() { }
        public Post(string title, string content)
        {
            Title = title;
            Content = content;
            PublishDate = DateTime.UtcNow;
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

        public void RemovePost(int id)

        {
            var deletePost = _postInteractions?.SingleOrDefault(s => s.Id == id);
            _postInteractions?.Remove(deletePost);
        }

        #endregion

        #region Post Interaction Methods

        public void Interact(int customerId, InteractionType type, int postId)
        {
            var postInteraction = new PostInteraction(customerId, type, postId);
            _postInteractions.Add(postInteraction);
        }

        public void UpdateInteract(int id, int customerId, InteractionType type, int postId)
        {
            var postInteraction = _postInteractions.FirstOrDefault(x => x.Id == id);
            postInteraction.UpdatePostInteraction(id, customerId, type, postId);
        }

        public void RemoveInteract(int id)
        {
            var postInteraction= _postInteractions?.FirstOrDefault(x => x.Id == id);
            _postInteractions.Remove(postInteraction);
        }


        #endregion

        #endregion
    }
}
