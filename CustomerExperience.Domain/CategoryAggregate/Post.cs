using CustomerExperience.Domain.Shared;

namespace CustomerExperience.Domain.CategoryAggregate
{
    public class Post:BaseEntity
    {
        #region Members
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishDate { get; private set; } = DateTime.Now;
        public int CategoryId { get; private set; }
        public int BlogId { get; private set; }

        public List<PostInteraction> _postInteractions { get; private set; } = new List<PostInteraction>();
        public Category? category { get; private set; }
        #endregion

        #region Constructors
        private Post() { }
        internal Post(string title, string content)
        {
            Title = title;
            Content = content;
            //CategoryId = categoryId;
            //BlogId = blogId;
        }

        #endregion

        #region Internal Methods
        internal void UpdatePost(int id, string? title, string? content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
        

        internal void Interact(PostInteraction postInteraction)
        {
            _postInteractions.Add(postInteraction);
        }

        #endregion
    }
}
