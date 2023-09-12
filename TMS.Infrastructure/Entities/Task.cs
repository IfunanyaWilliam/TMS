﻿namespace TMS.Infrastructure.Entities
{
    using System;
    using Domain.Task;
    public class Task
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
