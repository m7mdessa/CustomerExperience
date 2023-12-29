using CustomerExperience.Domain.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Application.Queries.Posts.GetAllPosts
{
    public class GetAllPostsDto
    {
        public int Id { get; set; }
        public string Title { get;  set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public InteractionType Type { get; set; }
    }
}
