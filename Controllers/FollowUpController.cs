using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMSCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EMSCore.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class FollowUpController : Controller
    {
        private readonly EMSContext _context;

        public FollowUpController(EMSContext context)
        {
            _context = context;
        }

        // GET: /FollowUp/List?enquiryId=5
        public async Task<IActionResult> List(int enquiryId)
        {
            var followUps = await _context.FollowUps
                .Where(f => f.EnquiryId == enquiryId)
                .OrderByDescending(f => f.Date)
                .ToListAsync();
            ViewBag.EnquiryId = enquiryId;
            return View(followUps);
        }

        // GET: /FollowUp/Add?enquiryId=5
        public IActionResult Add(int enquiryId)
        {
            var followUp = new FollowUp { EnquiryId = enquiryId };
            return View(followUp);
        }

        // POST: /FollowUp/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(FollowUp followUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(followUp);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Follow-up added successfully!";
            }
            return View(followUp);
        }
    }
}
