
namespace TMS.Application.Repository
{
    using Domain.User;

    public interface IUserRepository
    {
        Task<User> CreateUserAsync(
            string firstName,
            string lastName,
            string email,
            string password);
    }
}
