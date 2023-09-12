namespace TMS.Domain.User
{
    using System;
    using System.Collections.Generic;
    using Task;
    
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Task>? Tasks { get; set; }
    }
}
