using System;
using System.ComponentModel.DataAnnotations;

namespace EMSCore.Models
{
    public class Enquiry
    {
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string Contact { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Course { get; set; }

        [Required]
        public string Source { get; set; } // Walk-in, Phone, Web, etc.

        public string Priority { get; set; } // High, Medium, Low
        public string Status { get; set; } // New, In Progress, Converted, Dropped

        public int? AssignedStaffId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Enquiry()
        {
            Priority = "Medium";
            Status = "New";
        }
    }
}
