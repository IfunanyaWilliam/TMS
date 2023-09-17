﻿namespace TMS.Application.CommandHandlers.AppTask
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.AppTask;
    using Repository;
    using Domain.AppTask;

    public class CreateAppTaskCommandHandler
                : IRequestHandler<CreateAppTaskCommandParameter, AppTask>, IMediatRHandler
    {
        private readonly IAppTaskRepository _appTaskRepository;

        public CreateAppTaskCommandHandler(IAppTaskRepository appTaskRepository)
        {
            _appTaskRepository = appTaskRepository;
        }

        public Task<AppTask> Handle(
                    CreateAppTaskCommandParameter request, 
                    CancellationToken cancellationToken)
        {
            return _appTaskRepository.CreateTaskAsync(
                projectId: request.ProjectId,
                title: request.Title,
                description: request.Description,
                dueDate: request.DueDate,
                priority: request.Priority,
                status: request.Status);
        }
    }
}
