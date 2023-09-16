namespace TMS.Application.Commands.Project
{
    using MediatR;
    using TMS.Domain.Project;

    public class DeleteProjectCommandParameter : IRequest<bool>
    {
        public DeleteProjectCommandParameter(Guid id, ProjectStatus projectStatus) 
        {
            Id = id;
            ProjectStatus = projectStatus;
        }

        public Guid Id { get; }

        public ProjectStatus ProjectStatus { get; }
    }
}
