using CustomerExperience.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Domain.CategoryAggregate
{
    public class Post:BaseEntity
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishDate { get; private set; } = DateTime.Now;
        public int CategoryId { get; private set; }
        public int BlogId { get; private set; }

        public List<PostInteraction> _postInteractions { get; private set; } = new List<PostInteraction>();
        public Category? category { get; private set; }

        private Post() { }
        internal Post(string title, string content)
        {
            Title = title;
            Content = content;
            //CategoryId = categoryId;
            //BlogId = blogId;
        }

        internal void UpdatePost(int id, string? title, string? content)
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}
