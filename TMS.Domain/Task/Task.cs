namespace TMS.Domain.Task
{
    using System;
    using User;
    using Project;
    public class Task
    {
        public Task(
            Guid id,
            Guid userId,
            Guid projectId,
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status)
        {
            Id = id;
            UserId = userId;
            ProjectId = projectId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
        }
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
