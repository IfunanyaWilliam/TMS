namespace TMS.Application.Commands.Task
{
    using MediatR;
    using Domain.AppTask;

    public class CreateTaskCommandParameter : IRequest<AppTask>
    {
        public string Title { get; }

        public string Description { get; }

        public Guid ProjectId { get; }

        public DateTime DueDate { get; }

        public Priority Priority { get; }

        public Status Status { get; }
    }
}
