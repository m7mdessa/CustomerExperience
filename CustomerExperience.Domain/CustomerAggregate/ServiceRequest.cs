﻿using CustomerExperience.Domain.Shared;

namespace CustomerExperience.Domain.CustomerAggregate
{
    public class ServiceRequest:BaseEntity
    {


        #region Internal Methods
        internal void Update(int customerId, DateTime requestDate, string requestDescription)
        {
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