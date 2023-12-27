

using CustomerExperience.Domain.Shared;
using Microsoft.VisualBasic;

namespace CustomerExperience.Domain.CustomerAggregate
{
    public class Customer : BaseEntity,IAggregateRoot
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


        #endregion
    }
}
