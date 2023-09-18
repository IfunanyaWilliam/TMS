namespace TMS.Domain.User
{
    using System;
    
    public class User
    {
        public User(
            Guid id,
            string firstName,
            string lastName,
            string email,
            string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
