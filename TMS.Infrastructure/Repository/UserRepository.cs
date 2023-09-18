namespace TMS.Infrastructure.Repository
{
    using System;
    using DbContext;
    using Domain.User;

    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
             _context = context;
        }

        public async Task<User> CreateUserAsync(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName));

            if(string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException(nameof(lastName));

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var user = new Entities.User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            await _context.Users.AddAsync(user);
            var result = await _context.SaveChangesAsync();

            if(result > 0)
            {
                return new User(
                    id: user.Id,
                    firstName: user.FirstName,
                    lastName: user.LastName,
                    email: user.Email,
                    password: user.Password);
            }

            return null;
        }
    }
}
