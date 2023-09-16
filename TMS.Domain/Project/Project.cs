namespace TMS.Domain.Project
{
    using System;
    using System.Collections.Generic;
    using AppTask;

    public class Project
    {
        public Project(
            Guid id,
            string name,
            string description,
            IEnumerable<AppTask> tasks)
        {
            Id = id;
            Name = name;
            Description = description;
            AppTasks = tasks;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<AppTask>? AppTasks { get; set; }
    }
}
