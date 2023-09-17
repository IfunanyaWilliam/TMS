namespace TMS.Application.QueryHandlers.AppTask
{
    using MediatR;
    using Queries.AppTask;
    using Repository;
    using Domain.AppTask;
    using System.Threading.Tasks;
    using System.Threading;

    public class GetAppTaskQueryHandler
                : IRequestHandler<GetAppTaskByIdQueryParameter, AppTask>, IMediatRHandler
    {
        private readonly IAppTaskRepository _appTaskRepository;

        public GetAppTaskQueryHandler(IAppTaskRepository appTaskRepository)
        {
            _appTaskRepository = appTaskRepository;
        }

        public async Task<AppTask> Handle(
                        GetAppTaskByIdQueryParameter request, 
                        CancellationToken cancellationToken)
        {
            return await _appTaskRepository.GetTaskByIdAsync(id: request.Id);
        }
    }
}
