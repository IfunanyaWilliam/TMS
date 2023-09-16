namespace TMS.Infrastructure.Entities
{
    public class Project
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool? IsPending { get; set; }

        public List<AppTask>? AppTasks { get; set; }
    }
}
