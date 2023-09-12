namespace TMS.Domain.Notification
{
    using System;

    public class Notification
    {
        public Notification(
            Guid id,
            string message,
            DateTime timeStamp,
            NotificationType notificationType)
        {
            Id = id;
            Message = message;
            TimeStamp = timeStamp;
            NotificationType = notificationType;
        }
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
