using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMSCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EMSCore.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class CommunicationLogController : Controller
    {
        private readonly EMSContext _context;

        public CommunicationLogController(EMSContext context)
        {
            _context = context;
        }

        // GET: /CommunicationLog/List?enquiryId=5
        public async Task<IActionResult> List(int enquiryId)
        {
            var logs = await _context.CommunicationLogs
                .Where(l => l.EnquiryId == enquiryId)
                .OrderByDescending(l => l.SentAt)
                .ToListAsync();
            ViewBag.EnquiryId = enquiryId;
            return View(logs);
        }

        // GET: /CommunicationLog/Add?enquiryId=5
        public IActionResult Add(int enquiryId)
        {
            var log = new CommunicationLog { EnquiryId = enquiryId };
            return View(log);
        }

        // POST: /CommunicationLog/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CommunicationLog log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(log);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Communication log added successfully!";
            }
            return View(log);
        }
    }
}
