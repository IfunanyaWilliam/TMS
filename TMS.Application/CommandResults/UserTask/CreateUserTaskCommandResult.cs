using TMS.Domain.AppTask;

namespace TMS.Application.CommandResults.UserTask
{
    public class CreateUserTaskCommandResult
    {
        public CreateUserTaskCommandResult(
            Guid userTaskId,
            Guid userId,
            string fullName,
            IEnumerable<AppTask> tasks) 
        {
            UserTaskId = userTaskId;
            UserId = userId;
            FullName = fullName;
            Tasks = tasks;
        }

        public Guid UserTaskId { get; }

        public Guid UserId { get; }

        public string FullName { get; }

        public IEnumerable<AppTask> Tasks { get; }
    }
}
