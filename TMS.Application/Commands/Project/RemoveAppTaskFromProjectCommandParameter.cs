namespace TMS.Application.Commands.Project
{
    using MediatR;

    public class RemoveAppTaskFromProjectCommandParameter : IRequest<bool>
    {
        public RemoveAppTaskFromProjectCommandParameter(
            Guid appTaskId,
            Guid projectId)
        {
            ProjectId = projectId;
            AppTaskId = appTaskId;
        }

        public Guid AppTaskId { get; }

        public Guid ProjectId { get; }
    }
}
