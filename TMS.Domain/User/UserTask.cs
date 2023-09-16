namespace TMS.Domain.User
{
    using System;
    using System.Collections.Generic;
    using AppTask;

    public class UserTask
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<AppTask>? Tasks { get; set; }
    }
}
