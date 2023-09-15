namespace TMS.Application.CommandHandlers.Project
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Project;
    using Repository;

    public class UpdateProjectCommandHandler
                    : IRequestHandler<UpdateProjectCommandParameter, bool>, IMediatRHandler
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
              _projectRepository = projectRepository;   
        }

        public async Task<bool> Handle(
                    UpdateProjectCommandParameter request, 
                    CancellationToken cancellationToken)
        {
            return await _projectRepository.UpdateProjectAsync(
                id: request.Id,
                name: request.Name,
                description: request.Description);
        }
    }
}
