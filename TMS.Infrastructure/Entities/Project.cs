namespace TMS.Infrastructure.Entities
{
    using TMS.Domain.Project;

    public class Project
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        public List<AppTask>? AppTasks { get; set; }
    }
}
