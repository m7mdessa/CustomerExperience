﻿using MediatR;


namespace CustomerExperience.Application.Commands.Customers.CreateCustomer
{
    public class CreateCustomerCommand :IRequest<int>
    {
        public string? FirstName { get;  set; }
        public string? LastName { get;  set; }
        public string? Email { get;  set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }

        public string? Street { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }

    }
}
