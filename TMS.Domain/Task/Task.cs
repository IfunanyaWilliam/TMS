namespace TMS.Domain.Task
{
    using System;
    using User;
    public class Task
    {
        public Task(
            Guid id,
            Guid userId,
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
        }
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User Owner { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
