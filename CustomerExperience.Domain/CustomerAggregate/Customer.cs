
using CustomerExperience.Packages;

namespace CustomerExperience.Domain.CustomerAggregate
{
    public class Customer : AggregateRootEntity
    {

      
        private readonly List<Feedback> _feedbacks = new();
        private readonly List<ServiceRequest> _serviceRequests = new();


        #region Constructors

        private Customer()
        {
        }

        public Customer(string firstName, string lastName, string email, string phoneNumber,Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
  
        }



        #endregion


        #region Members
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public virtual IReadOnlyCollection<Feedback> Feedbacks => _feedbacks;
        public virtual IReadOnlyCollection<ServiceRequest> ServiceRequests => _serviceRequests;


        #endregion

        #region Public Methods
        public void AddFeedback(int customerId, DateTime feedbackDate, string feedbackText)
        {

            var feedBack = new Feedback(customerId, feedbackDate, feedbackText);

            _feedbacks.Add(feedBack);
        }
        public void UpdateFeedback(int customerId, DateTime feedbackDate, string feedbackText)
        {
            var feedBack = _feedbacks.FirstOrDefault(x => x.CustomerId == customerId);


            feedBack?.Update(customerId, feedbackDate, feedbackText);
        }

        public void RemoveFeedback(Feedback feedBack)
        {
            _feedbacks.Remove(feedBack);
        }



        public void AddServiceRequest(int customerId, DateTime requestDate, string requestDescription)
        {

            var serviceRequest = new ServiceRequest(customerId, requestDate, requestDescription);

            _serviceRequests.Add(serviceRequest);
        }
        public void UpdateServiceRequest(int customerId, DateTime requestDate, string requestDescription)
        {
            var serviceRequest = _serviceRequests.FirstOrDefault(x => x.CustomerId == customerId);


            serviceRequest?.Update(customerId, requestDate, requestDescription);
        }

        public void RemoveServiceRequest(ServiceRequest serviceRequest)
        {
            _serviceRequests.Remove(serviceRequest);
        }





        #endregion





    }
}
