namespace TMS.Application.QueryHandlers
{
    using MediatR;
    using Queries.Project;
    using Repository;
    using System.Threading;
    using System.Threading.Tasks;
    using TMS.Domain.Project;

    public class GetAllProjectsQueryHandler 
                        : IRequestHandler<GetAllProjectsQueryParamter, IEnumerable<Project>>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Handle(
                        GetAllProjectsQueryParamter request, 
                        CancellationToken cancellationToken)
        {
            return await _projectRepository.GetAllProjectsAsyn(
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                searchParam: request.SearchParam);
        }
    }
}
