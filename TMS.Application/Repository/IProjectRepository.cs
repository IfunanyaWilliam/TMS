﻿namespace TMS.Application.Repository
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

        Task<bool> UpdateProjectAsync(Guid id, string name, string description, ProjectStatus projectStatus);

        Task<bool> AddAppTaskToProject(Guid projectId, Guid appTaskId);

        Task<bool> RemoveAppTaskFromProject(Guid projectId, Guid appTaskId);

        Task<bool> DeleteProjectAsync(Guid id, ProjectStatus projectStatus);
    }
}
