﻿namespace TMS.Infrastructure.Entities
{
    using System;
    using TMS.Domain.AppTask;

    public class AppTask
    {
        public Guid Id { get; set; }
        
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
