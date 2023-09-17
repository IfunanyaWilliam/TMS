namespace TMS.Domain.AppTask
{
    using System;
    using Project;

    public class AppTask
    {
        public AppTask(
            Guid id,
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
        }
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
