namespace TMS.Domain.Project
{
    using System;
    using System.Collections.Generic;
    using Task;

    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
