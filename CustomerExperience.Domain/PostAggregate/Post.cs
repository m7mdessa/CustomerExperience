using CustomerExperience.Packages;

namespace CustomerExperience.Domain.PostAggregate
{
<<<<<<< HEAD
    public class Post : AuditableEntity
=======
    public class Post: AggregateRootEntity
>>>>>>> 4b383a5a9abc0ca5c896efd4b7275108c1141a1e
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

<<<<<<< HEAD
        internal void RemovePost(int id)
=======
        public void DeletePost(int id)
>>>>>>> 4b383a5a9abc0ca5c896efd4b7275108c1141a1e
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

        internal void UpdateInteract(int id, int customerId, InteractionType type, int postId)
        {
            var postInteraction = _postInteractions.FirstOrDefault(x => x.Id == id);
            postInteraction.UpdatePostInteraction(id, customerId, type, postId);
        }

        internal void RemoveInteract(int id)
        {
            var postInteraction= _postInteractions?.FirstOrDefault(x => x.Id == id);
            _postInteractions.Remove(postInteraction);
        }


        #endregion

        #endregion
    }
}
