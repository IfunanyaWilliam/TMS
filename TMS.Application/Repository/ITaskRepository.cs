namespace TMS.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using TMS.Domain.AppTask;

    public interface ITaskRepository
    {
        Task<IEnumerable<AppTask>> GetAllTaskAsync(
            int pageNumber,
            int pageSize,
            string searchParam);

        Task<AppTask> GetTaskByIdAsync(Guid id);

        Task<bool> CreateTaskAsync(
            Guid UserId,
            Guid projectId,
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status);

        Task<bool> UpdateTaskAsync(Guid id,
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status);

        Task<bool> DeleteTaskAsync(Guid id);
    }
}
