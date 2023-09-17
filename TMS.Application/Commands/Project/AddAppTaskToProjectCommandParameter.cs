namespace TMS.Application.Commands.Project
{
    using MediatR;
    public class AddAppTaskToProjectCommandParameter : IRequest<bool>
    {
        public AddAppTaskToProjectCommandParameter(
            Guid projectId,
            Guid appTaskId)
        {
            ProjectId = projectId;
            AppTaskId = appTaskId;
        }

        public Guid ProjectId { get; }

        public Guid AppTaskId { get; }
    }
}
