using CustomerExperience.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Domain.CategoryAggregate
{
    public class Category : BaseEntity, IAggregateRoot
    {
        #region Members
        public string Name { get; private set; }

        public List<Post>? _posts;
        public IReadOnlyCollection<Post>? Posts => _posts;

        #endregion

        #region Constructors
        private Category() { _posts = new List<Post>(); }

        public Category(string name) {  Name = name; }

        #endregion

        #region Public Methods

        public void DeleteCategory(int id)
        {
            var deleteCategory = _posts?.SingleOrDefault(s => s.CategoryId == id);
            _posts?.Remove(deleteCategory);
        }

        public void EditCategoryInfo(int id, string? name)
        {
            Id = id;
            Name = name;
        }


        public void Post(string title , string content)
        {
            var addPost = new Post(title, content);
            _posts?.Add(addPost);
        }

        public void UpdatePost(int id, string? title, string? content)
        {
            var getPostById = _posts?.SingleOrDefault(s => s.Id == id);
            if (getPostById != null)
            {
                getPostById.UpdatePost(id, title, content);
            }
        }

        public void DeletePost(int id)
        {
            var getPostById = _posts?.FirstOrDefault(s => s.Id == id);

            if (getPostById != null)
            {
                _posts?.Remove(getPostById);
            }
        }

        public void Interact(int postId, PostInteraction postInteraction)
        {
            var postById = _posts?.FirstOrDefault(s => s.Id == postId);
            _posts?.Interact(postInteraction);
        }

        #endregion
    }
}
