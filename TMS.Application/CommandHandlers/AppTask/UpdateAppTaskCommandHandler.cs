namespace TMS.Application.CommandHandlers.AppTask
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.AppTask;
    using Repository;

    public class UpdateAppTaskCommandHandler
                : IRequestHandler<UpdateAppTaskCommandParameter, bool>, IMediatRHandler
    {
        private readonly IAppTaskRepository _appTaskRepository;

        public UpdateAppTaskCommandHandler(IAppTaskRepository appTaskRepository)
        {
            _appTaskRepository = appTaskRepository;
        }

        public async Task<bool> Handle(
                        UpdateAppTaskCommandParameter request, 
                        CancellationToken cancellationToken)
        {
            return await _appTaskRepository.UpdateTaskAsync(
                id: request.Id,
                title: request.Title,
                description: request.Description,
                dueDate: request.DueDate,
                priority: request.Priority,
                status: request.Status);
        }
    }
}
