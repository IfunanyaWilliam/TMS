namespace TMS.Infrastructure.Entities
{
    using System;
    using Domain.Notification;

    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
