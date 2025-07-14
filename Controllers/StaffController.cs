using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMSCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EMSCore.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class StaffController : Controller
    {
        private readonly EMSContext _context;

        public StaffController(EMSContext context)
        {
            _context = context;
        }

        // GET: /Staff/
        public async Task<IActionResult> Index()
        {
            var staffList = await _context.Staffs.ToListAsync();
            return View(staffList);
        }

        // GET: /Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Staff/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Staff member added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: /Staff/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
                return NotFound();
            return View(staff);
        }
    }
}
