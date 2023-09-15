namespace TMS.Application.CommandHandlers.Project
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Project;
    using Repository;
    using TMS.Domain.Project;

    public class CreateProjectCommandHandler 
                       : IRequestHandler<CreateProjectCommandParameter, Project>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(
                        CreateProjectCommandParameter request, 
                        CancellationToken cancellationToken)
        {
            return await _projectRepository.CreateProjectAsyn(
                            request.Name,
                            request.Description);
        }
    }
}
