using System;

namespace EMSCore.Models
{
    public class FollowUp
    {
        public int Id { get; set; }
        public int EnquiryId { get; set; }
        public int StaffId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public bool ReminderSent { get; set; }
    }
}
