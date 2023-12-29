using CustomerExperience.Packages;

namespace CustomerExperience.Domain.CustomerAggregate
{
    public class ServiceRequest:AuditableEntity
    {


        #region Internal Methods
        internal void Update(int id,int customerId, DateTime requestDate, string requestDescription)
        {
            Id = id;
            CustomerId = customerId;
            RequestDate = requestDate;
            RequestDescription = requestDescription;
        }


        #endregion

        #region Constructors

        private ServiceRequest()
        {
        }
        internal ServiceRequest(int customerId, DateTime requestDate, string requestDescription)
        {
            CustomerId = customerId;
            RequestDate = requestDate;
            RequestDescription = requestDescription;
        }

        #endregion

        #region Members
        public int CustomerId { get; private set; }
        public DateTime RequestDate { get; private set; }
        public string RequestDescription { get; private set; }

        public Customer Customer { get; private set; }
        #endregion

    }
}