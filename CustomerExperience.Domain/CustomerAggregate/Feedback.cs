using CustomerExperience.Packages;

namespace CustomerExperience.Domain.CustomerAggregate
{
    public class Feedback : AuditableEntity
    {


        #region Constructors

        private Feedback()
        {
        }
        internal Feedback( int customerId, DateTime feedbackDate, string feedbackText)
        {
            CustomerId = customerId;
            FeedbackDate = feedbackDate;
            FeedbackText = feedbackText;
        }
        #endregion


        #region Internal Methods
        internal void Update(int customerId, DateTime feedbackDate, string feedbackText)
        {
            CustomerId = customerId;
            FeedbackDate = feedbackDate;
            FeedbackText = feedbackText;
        }


        #endregion

        #region Members
        public int CustomerId { get; private set; }
        public DateTime FeedbackDate { get; private set; }
        public string FeedbackText { get; private set; }

        public Customer Customer { get; private set; }
        #endregion

    }
}