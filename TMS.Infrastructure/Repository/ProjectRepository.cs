﻿namespace TMS.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using DbContext;
    using Domain.Project;
    using Domain.AppTask;
    using System.Linq;
    using Application.Repository;

    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsyn(
            int pageNumber,
            int pageSize,
            string searchParam)
        {
            var skip = (pageNumber - 1) * pageSize;

            Expression<Func<Entities.Project, bool>> predicate = null;

            if(!string.IsNullOrEmpty(searchParam))
                predicate = s => ((s.ProjectStatus == ProjectStatus.Created || s.ProjectStatus == ProjectStatus.InProgress 
                                             || s.ProjectStatus == ProjectStatus.Completed) 
                                        && (s.Name.ToLower() == searchParam.ToLower())) 
                                || (s.ProjectStatus == ProjectStatus.Created || s.ProjectStatus == ProjectStatus.InProgress 
                                        || s.ProjectStatus == ProjectStatus.Completed);


            var projects = await _context.Projects
                .Where(predicate)
                .Include(t => t.AppTasks)
                .OrderByDescending(n => n.Name)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            if(projects.Count <= 0 || projects == null)
            {
                return null;
            }

            List<Project> newProject = new List<Project>();

            for(int i = 0; i < projects.Count; i++)
            {
                var project = projects[i];  
                var AppTaskIsNull = project.AppTasks.Any();

                if (AppTaskIsNull)
                {
                    newProject.Add(new Project(
                        id: project.Id,
                        name: project.Name,
                        description: project.Description,
                        projectStatus: project.ProjectStatus,
                        tasks: project.AppTasks.Select(t => new AppTask(
                            id: t.Id,
                            title: t.Title,
                            description: t.Description,
                            dueDate: t.DueDate,
                            priority: t.Priority,
                            status: t.Status))));
                }
                else
                {
                    newProject.Add(new Project(
                        id: project.Id,
                        name: project.Name,
                        description: project.Description,
                        projectStatus: project.ProjectStatus,
                        tasks: Enumerable.Empty<AppTask>()));
                   
                }
            }

            return newProject;
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            var project = await _context.Projects
                .Include(p => p.AppTasks)        
                .FirstOrDefaultAsync(i => i.Id == id);


            if (project == null)
                return null;

            var AppTaskIsNull = project.AppTasks.Any();

            if (AppTaskIsNull)
                return new Project(
                    id: project.Id,
                    name: project.Name,
                    description: project.Description,
                    projectStatus: project.ProjectStatus,
                    tasks: project.AppTasks.Select(t => new AppTask(
                        id: t.Id,
                        title: t.Title,
                        description: t.Description,
                        dueDate: t.DueDate,
                        priority: t.Priority,
                        status: t.Status)));
            else
                return new Project(
                            id: project.Id,
                            name: project.Name,
                            description: project.Description,
                            projectStatus: project.ProjectStatus,
                            tasks: Enumerable.Empty<AppTask>());

            return null;
        }

        public async Task<Project> CreateProjectAsyn(string name, string description)
        {
            var project = new Entities.Project
            {
                Name = name,
                Description = description,
                ProjectStatus = ProjectStatus.Created,
                AppTasks = null
            };

            await _context.Projects.AddAsync(project);
            var result =  await _context.SaveChangesAsync();
            
            if(result > 0)
            {
                return new Project(
                    id: project.Id,
                    name: project.Name,
                    description: project.Description,
                    projectStatus: project.ProjectStatus,
                    tasks: Enumerable.Empty<AppTask>());
            }

            return null;
        }

        public async Task<bool> UpdateProjectAsync(
                        Guid id, 
                        string name, 
                        string description,
                        ProjectStatus projectStatus)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
                return false;

            var existingProject = await _context.Projects.FindAsync(id);

            if(existingProject == null)
                return false;

            existingProject.Name = name ?? existingProject.Name;
            existingProject.Description = description ?? existingProject.Description;
            existingProject.ProjectStatus = projectStatus;

            _context.Update(existingProject);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddAppTaskToProject(Guid projectId, Guid appTaskId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if(project == null) 
                return false;

            var appTask = await _context.AppTasks.FindAsync(appTaskId);
            if (appTask == null)
                return false;

            if(!project.AppTasks.Where(i => i.Id == appTaskId).Any()) //Implement custom message that says, Project already contains the task
                return false;

            project.AppTasks.Add(appTask);
            _context.Update(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveAppTaskFromProject(Guid projectId, Guid appTaskId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null)
                return false;

            var appTask = await _context.AppTasks.FindAsync(appTaskId);
            if (appTask == null)
                return false;

            if (!project.AppTasks.Where(i => i.Id == appTaskId).Any()) //Implement custom message that says, Task is not contained in Project
                return false;

            project.AppTasks.Remove(appTask);
            _context.Update(project);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProjectAsync(Guid id, ProjectStatus projectStatus)
        {
            if(id == Guid.Empty)
                return false;

            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProject == null)
                return false;

            existingProject.ProjectStatus = projectStatus;
            _context.Update(existingProject);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
