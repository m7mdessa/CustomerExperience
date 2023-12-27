using CustomerExperience.Domain.Shared;

namespace CustomerExperience.Domain.CustomerAggregate
{
    public class Feedback :BaseEntity
    {
        public int FeedbackID { get; private set; }
        public int CustomerID { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string FeedbackText { get; private set; }

        public Customer Customer { get; private set; }


        private Feedback()
        {
        }

        internal Feedback(int feedbackID, int customerID, DateTime timestamp, string feedbackText)
        {
            FeedbackID = feedbackID;
            CustomerID = customerID;
            Timestamp = timestamp;
            FeedbackText = feedbackText;
        }
    }
}