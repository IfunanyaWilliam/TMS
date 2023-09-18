namespace TMS.Application.CommandHandlers.User
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.User;
    using Domain.User;
    using Repository;

    public class CreateUserCommandHandler
             : IRequestHandler<CreateUserCommandParameter, User>, IMediatRHandler
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(
                        CreateUserCommandParameter request, 
                        CancellationToken cancellationToken)
        {
            return await _userRepository.CreateUserAsync(
                firstName: request.FirstName,
                lastName: request.LastName,
                email: request.Email,
                password: request.Password);
        }
    }
}
