﻿namespace TMS.Application.Commands.AppTask
{
    using MediatR;
    using Domain.AppTask;

    public class CreateAppTaskCommandParameter : IRequest<AppTask>
    {
        public CreateAppTaskCommandParameter(
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
        }
        public string Title { get; }

        public string Description { get; }

        public DateTime DueDate { get; }

        public Priority Priority { get; }

        public Status Status { get; }
    }
}
