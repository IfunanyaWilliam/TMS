namespace TMS.Application.CommandHandlers.Project
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Project;
    using Repository;
    internal class RemoveAppTaskFromProjectCommandHandler
                : IRequestHandler<RemoveAppTaskFromProjectCommandParameter, bool>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;

        public RemoveAppTaskFromProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(
                    RemoveAppTaskFromProjectCommandParameter request, 
                    CancellationToken cancellationToken)
        {
            return await _projectRepository.RemoveAppTaskFromProject(
                projectId: request.ProjectId,
                appTaskId: request.AppTaskId);
        }
    }
}
