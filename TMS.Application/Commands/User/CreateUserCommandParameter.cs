namespace TMS.Application.Commands.User
{
    using MediatR;
    using Domain.User;

    public class CreateUserCommandParameter : IRequest<User>
    {
        public CreateUserCommandParameter(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
