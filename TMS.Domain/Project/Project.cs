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
            string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Task>? Tasks { get; set; }
    }
}
