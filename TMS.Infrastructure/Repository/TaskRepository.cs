namespace TMS.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using DbContext;
    using Domain.Task;
    using TMS.Application.Repository;

    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetAllTaskAsync(
            int pageNumber,
            int pageSize,
            string searchParam)
        {
            var skip = (pageNumber - 1) * pageSize;

            Expression<Func<Entities.Task, bool>> predicate = null;

            if (!string.IsNullOrEmpty(searchParam))
            {
                predicate = s => s.Title.ToLower() == searchParam.ToLower();
            }
            else
                predicate = null;

            var tasks = await _context.Tasks
                .Where(predicate)
                .OrderByDescending(n => n.Title)
                .Take(pageSize)
                .Skip(skip)
                .ToListAsync();

            if(tasks == null)
                return Enumerable.Empty<Task>();

            return tasks.Select(t => new Task(
                id: t.Id,
                userId: t.UserId,
                projectId: t.ProjectId,
                title: t.Title,
                description: t.Description,
                dueDate: t.DueDate,
                priority: t.Priority,
                status: t.Status));
        }

        public async Task<Task> GetTaskByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            var task =  await _context.Tasks.FindAsync(id);

            if(task == null)
                return null;

            return new Task(
                id: task.Id,
                userId: task.UserId,
                projectId: task.ProjectId,
                title: task.Title,
                description: task.Description,
                dueDate: task.DueDate,
                priority: task.Priority,
                status: task.Status);
        }

        public async Task<bool> CreateTaskAsync(
            Guid UserId,
            Guid projectId,
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status)
        {
            if(UserId == Guid.Empty || projectId == Guid.Empty || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                return false;

            var task = new Entities.Task
            {
                UserId = UserId,
                ProjectId = projectId,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority,
                Status = status
            };

            await _context.Tasks.AddAsync(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateTaskAsync(Guid id,
            string title,
            string description,
            DateTime dueDate,
            Priority priority,
            Status status)
        {
            if(id == Guid.Empty) 
                return false;

            var existingTask = await _context.Tasks.FindAsync(id);

            if(existingTask == null)
                return false;

            existingTask.Title = title ?? existingTask.Title;
            existingTask.Description = description ?? existingTask.Description;
            existingTask.DueDate = dueDate;
            existingTask.Priority = priority;
            existingTask.Status = status;

            _context.Update(existingTask);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            if(id == Guid.Empty)
                return false;

            var existingTask = await _context.Tasks.FindAsync(id);

            if (existingTask != null) //To DO => return not found
                return false;

            _context.Tasks.Remove(existingTask);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
