namespace TMS.Application.Commands.AppTask
{
    using MediatR;
    using Domain.AppTask;

    public class UpdateAppTaskCommandParameter : IRequest<bool>
    {
        public UpdateAppTaskCommandParameter(
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

        public Guid Id { get; }
        public string Title { get; }

        public string Description { get; }

        public DateTime DueDate { get; }

        public Priority Priority { get; }

        public Status Status { get; }
    }
}
