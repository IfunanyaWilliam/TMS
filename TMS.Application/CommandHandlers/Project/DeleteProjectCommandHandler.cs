namespace TMS.Application.CommandHandlers.Project
{
    using MediatR;
    using Commands.Project;
    using Repository;
    using System.Threading.Tasks;
    using System.Threading;

    public class DeleteProjectCommandHandler
                : IRequestHandler<DeleteProjectCommandParameter, bool>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(
                            DeleteProjectCommandParameter request, 
                            CancellationToken cancellationToken)
        {
            return  await _projectRepository.DeleteProjectAsync(
                        id: request.Id,
                        projectStatus: request.ProjectStatus);
        }
    }
}
