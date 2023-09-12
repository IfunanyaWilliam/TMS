namespace TMS.Domain.Notification
{
    using System;

    public class Notification
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
