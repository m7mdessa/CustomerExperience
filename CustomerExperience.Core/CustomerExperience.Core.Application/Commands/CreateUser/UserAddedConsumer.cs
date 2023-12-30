//using CustomerExperience.Core.Application.Commands.CreateUser;
//using MassTransit;
//using Microsoft.Extensions.Logging;

//namespace Application.Commands.Users.AddUser
//{
//    public class UserAddedConsumer : IConsumer<CreateUserCommand>
//    {
//        private readonly ILogger<UserAddedConsumer> _logger;

//        public UserAddedConsumer(ILogger<UserAddedConsumer> logger)
//        {
//            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//        }

//        public async Task Consume(ConsumeContext<CreateUserCommand> context)
//        {
//            Console.WriteLine("Consume method called");
//            var userName = context.Message.UserName;
//            var customerId = context.Message.CustomerId;

//            _logger.LogInformation(
//                "UserAdded message received. CustomerId: {CustomerId}, UserName: {UserName}",
//                customerId, userName);

//            Console.WriteLine(
//                $"UserAdded message received. CustomerId: {customerId}, UserName: {userName}");

            
//        }
//    }

//}

