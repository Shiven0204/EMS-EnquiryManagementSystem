using System;

namespace EMSCore.Models
{
    public class CommunicationLog
    {
        public int Id { get; set; }
        public int EnquiryId { get; set; }
        public string Type { get; set; } // Email, SMS, WhatsApp, Note, etc.
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsInternal { get; set; }
    }
}
