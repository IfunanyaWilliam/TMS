namespace TMS.Infrastructure.Repository
{
    using Application.CommandResults.UserTask;
    using Infrastructure.DbContext;
    using Microsoft.EntityFrameworkCore;

    public class UserTaskRepository
    {
        private readonly AppDbContext _context;

        public UserTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateUserTaskCommandResult> CreateUserTaskAsync(
                Guid userId)
        {
            var existingUserTask = await _context.UsersTasks.FirstOrDefaultAsync(x => x.UserId == userId);

            if (existingUserTask != null)
                return new CreateUserTaskCommandResult(
                    userTaskId: existingUserTask.Id, userId: existingUserTask.UserId);

            var userTask = new Entities.UserTask
            {
                UserId = userId
            };

            await _context.UsersTasks.AddAsync(userTask);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return new CreateUserTaskCommandResult(
                    userTaskId: userTask.Id, userId: userTask.UserId);
            }

            return null;
        }
    }
}
