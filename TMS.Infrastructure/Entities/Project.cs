namespace TMS.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Task>? Tasks { get; set; }
    }
}
