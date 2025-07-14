using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMSCore.Models
{
    public class EMSContext : IdentityDbContext
    {
        public EMSContext(DbContextOptions<EMSContext> options) : base(options) { }

        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<FollowUp> FollowUps { get; set; }
        public DbSet<CommunicationLog> CommunicationLogs { get; set; }
    }
}
