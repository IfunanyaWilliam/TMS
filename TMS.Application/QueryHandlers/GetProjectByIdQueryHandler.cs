namespace TMS.Application.QueryHandlers
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TMS.Application.Queries.Project;
    using TMS.Application.Repository;
    using TMS.Domain.Project;

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryParameter, Project>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<Project> Handle(
            GetProjectByIdQueryParameter request, 
            CancellationToken cancellationToken)
        {
            return _projectRepository.GetProjectByIdAsync(request.Id);
        }
    }
}
