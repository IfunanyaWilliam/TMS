namespace TMS.Application.QueryHandlers.AppTask
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TMS.Application.Queries.AppTask;
    using TMS.Application.Repository;
    using TMS.Domain.AppTask;

    public class GetAllAppTasksQueryHandler
                : IRequestHandler<GetAllAppTasksQueryParameter, IEnumerable<AppTask>>, IMediatRHandler
    {
        private readonly IAppTaskRepository _appTaskRepository;

        public GetAllAppTasksQueryHandler(IAppTaskRepository appTaskRepository)
        {
             _appTaskRepository = appTaskRepository;
        }

        public async Task<IEnumerable<AppTask>> Handle(
                            GetAllAppTasksQueryParameter request, 
                            CancellationToken cancellationToken)
        {
            return await _appTaskRepository.GetAllTaskAsync(
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                searchParam: request.SearchParam);
        }
    }
}
