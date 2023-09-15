namespace TMS.Application.Repository
{
    using System;
    using System.Collections.Generic;
    using TMS.Domain.Project;

    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsyn(
            int pageNumber,
            int pageSize,
            string searchParam);

        Task<Project> GetProjectByIdAsync(Guid id);

        Task<Project> CreateProjectAsyn(string name, string description);

        Task<bool> UpdateProjectAsync(Guid id, string name, string description);

        Task<bool> DeleteProjectAsync(Guid id);
    }
}
