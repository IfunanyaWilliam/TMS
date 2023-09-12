namespace TMS.Domain.User
{
    using System;
    using System.Collections.Generic;
    using Task;

    public class UserTask
    {
        public UserTask(
            Guid id,
            Guid userId,
            IEnumerable<Task>? tasks)
        {
            Id = id;
            UserId = userId;
            Tasks = tasks;
        }
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<Task>? Tasks { get; set; }
    }
}
