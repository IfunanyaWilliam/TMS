﻿namespace TMS.Domain.Task
{
    using System;
    using User;
    public class Task
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User Owner { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
