namespace TMS.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;

    public class UserTask
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<AppTask>? Tasks { get; set; }
    }
}
