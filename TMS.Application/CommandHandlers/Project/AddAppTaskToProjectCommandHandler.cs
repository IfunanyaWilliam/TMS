namespace TMS.Application.CommandHandlers.Project
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Project;
    using Repository;

    public class AddAppTaskToProjectCommandHandler
                : IRequestHandler<AddAppTaskToProjectCommandParameter, bool>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;

        public AddAppTaskToProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task<bool> Handle(
                        AddAppTaskToProjectCommandParameter request, 
                        CancellationToken cancellationToken)
        {
            return _projectRepository.AddAppTaskToProject(
                projectId: request.ProjectId,
                appTaskId: request.AppTaskId);
        }
    }
}
