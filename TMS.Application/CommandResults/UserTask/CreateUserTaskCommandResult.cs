namespace TMS.Application.CommandResults.UserTask
{
    public class CreateUserTaskCommandResult
    {
        public CreateUserTaskCommandResult(
            Guid userTaskId,
            Guid userId) 
        {
            UserTaskId = userTaskId;
            UserId = userId;
        }

        public Guid UserTaskId { get; }
        public Guid UserId { get; }
    }
}
