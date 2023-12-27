﻿using CustomerExperience.Domain.Shared;


namespace CustomerExperience.Domain.CategoryAggregate
{
    public class PostInteraction: BaseEntity
    {

        #region Members
        public InteractionType Type { get; private set; }
        public DateTime Timestamp { get; private set; } = DateTime.Now;
        public int CustomerId { get; private set; }
        public int PostId { get; private set; }
        public Post? Post { get; private set; }

        #endregion

        #region Constructors
        private PostInteraction() { }

        internal PostInteraction(int customerId, InteractionType type, int postId)
        {
            CustomerId = customerId;
            Type = type;
            PostId = postId;
        }

        #endregion

        #region Internal Methods
        internal void UpdatePostInteraction(int id,int customerId, InteractionType type, int postId)
        {
            Id = id;
            CustomerId = customerId;
            Type = type;
            PostId = postId;
        }

        #endregion
    }
}
