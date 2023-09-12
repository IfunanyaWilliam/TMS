namespace TMS.Domain.Project
{
    using System;
    using System.Collections.Generic;
    using Task;

    public class Project
    {
        public Project(
            Guid id,
            string name,
            string description,
            IEnumerable<Task>? tasks)
        {
            Id = id;
            Name = name;
            Description = description;
            Tasks = tasks;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Task>? Tasks { get; set; }
    }
}
