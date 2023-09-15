namespace TMS.Infrastructure.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using DbContext;
    using Domain.Project;
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
            {
                predicate = s => (s.Name.ToLower() == searchParam.ToLower() || s.IsPending == false);
            }
            else 
                predicate = s => s.IsPending == false;

            var projects = await _context.Projects
                .Where(predicate)
                .OrderByDescending(n => n.Name)
                .Take(pageSize)
                .Skip(skip)
                .ToListAsync();

            if(!projects.Any() || projects == null)
            {
                return null;
            }

            return projects.Select(p => new Project(
                id: p.Id,
                name: p.Name,
                description: p.Description));
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            var project = await _context.Projects.FindAsync(id);

            return new Project(
                id: project.Id,
                name: project.Name,
                description: project.Description);
        }

        public async Task<Project> CreateProjectAsyn(string name, string description)
        {
            
            var project = new Entities.Project
            {
                Name = name,
                Description = description,
                IsPending = false
            };

            await _context.Projects.AddAsync(project);
            var result =  await _context.SaveChangesAsync();
            
            if(result > 0)
            {
                return new Project(
                    id: project.Id,
                    name: project.Name,
                    description: project.Description);
            }

            return null;
        }

        public async Task<bool> UpdateProjectAsync(Guid id, string name, string description)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
                return false;

            var existingProject = await _context.Projects.FindAsync(id);

            if(existingProject == null)
                return false;

            existingProject.Name = name ?? existingProject.Name;
            existingProject.Description = description ?? existingProject.Description;

            _context.Update(existingProject);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            if(id == Guid.Empty)
                return false;

            var existingProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProject != null)
                return false;

             _context.Projects.Remove(existingProject);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
