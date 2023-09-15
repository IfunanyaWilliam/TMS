namespace TMS.Application.CommandHandlers.Project
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands.Project;
    using Repository;

    public class CreateProjectCommandHandler 
                       : IRequestHandler<CreateProjectCommandParameter, bool>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(
                    CreateProjectCommandParameter request, 
                    CancellationToken cancellationToken)
        {
            return await _projectRepository.CreateProjectAsyn(request.Name, request.Description);
        }
    }
}
