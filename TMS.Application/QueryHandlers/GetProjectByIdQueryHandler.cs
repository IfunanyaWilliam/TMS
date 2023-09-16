namespace TMS.Application.QueryHandlers
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TMS.Application.Queries.Project;
    using TMS.Application.Repository;
    using TMS.Domain.Project;

    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryParameter, Project>
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
            throw new NotImplementedException();
        }
    }
}
