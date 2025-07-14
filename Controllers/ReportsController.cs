using Microsoft.AspNetCore.Mvc;
using EMSCore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace EMSCore.Controllers
{
    [Authorize(Roles = "Admin,Staff,Student")]
    public class ReportsController : Controller
    {
        private readonly EMSContext _context;

        public ReportsController(EMSContext context)
        {
            _context = context;
        }

        // GET: /Reports/Dashboard
        public IActionResult Dashboard()
        {
            // Prepare data for the chart: count of enquiries by source
            var sourceCounts = _context.Enquiries
                .GroupBy(e => e.Source)
                .Select(g => new { Source = g.Key, Count = g.Count() })
                .ToList();

            ViewBag.SourceCounts = sourceCounts;
            ViewBag.TotalEnquiries = _context.Enquiries.Count();
            ViewBag.Converted = _context.Enquiries.Count(e => e.Status == "Converted");
            ViewBag.Dropped = _context.Enquiries.Count(e => e.Status == "Dropped");

            return View();
        }
    }
}
