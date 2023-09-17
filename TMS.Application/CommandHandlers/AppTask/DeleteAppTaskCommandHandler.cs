namespace TMS.Application.CommandHandlers.AppTask
{
    using MediatR;
    using Commands.AppTask;
    using Repository;
    using System.Threading.Tasks;
    using System.Threading;

    public class DeleteAppTaskCommandHandler
                : IRequestHandler<DeleteAppTaskCommandParameter, bool>, IMediatRHandler
    {
        private readonly IAppTaskRepository _appTaskRepository;

        public DeleteAppTaskCommandHandler(IAppTaskRepository appTaskRepository)
        {
            _appTaskRepository = appTaskRepository;
        }

        public async Task<bool> Handle(
                        DeleteAppTaskCommandParameter request, 
                        CancellationToken cancellationToken)
        {
            return await _appTaskRepository.DeleteTaskAsync(id: request.Id);
        }
    }
}
