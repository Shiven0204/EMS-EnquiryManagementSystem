using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EMSCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EMSCore.Controllers
{
    [Authorize(Roles = "Admin,Staff,Student")]
    public class EnquiryController : Controller
    {
        private readonly EMSContext _context;

        public EnquiryController(EMSContext context)
        {
            _context = context;
        }

        // GET: /Enquiry/
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Student"))
            {
                var email = User.Identity.Name;
                var enquiries = await _context.Enquiries.Where(e => e.Email == email).ToListAsync();
                return View(enquiries);
            }
            else
            {
                var enquiries = await _context.Enquiries.ToListAsync();
                return View(enquiries);
            }
        }

        // GET: /Enquiry/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Enquiry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Set default values
                    enquiry.Status = "New";
                    enquiry.Priority = "Medium";
                    enquiry.CreatedAt = DateTime.Now;
                    _context.Add(enquiry);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Enquiry added successfully!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Database error: {ex.Message}");
                }
            }
            else
            {
                // Add all ModelState errors to TempData for debugging
                TempData["DebugErrors"] = string.Join("; ", ModelState.SelectMany(x => x.Value.Errors).Select(e => e.ErrorMessage));
            }
            return View(enquiry);
        }

        // GET: /Enquiry/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);
            if (enquiry == null)
                return NotFound();
            return View(enquiry);
        }

        // GET: /Enquiry/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);
            if (enquiry == null)
                return NotFound();
            if (User.IsInRole("Student") && enquiry.Email != User.Identity.Name)
                return Forbid();
            return View(enquiry);
        }

        // POST: /Enquiry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Enquiry model)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);
            if (enquiry == null)
                return NotFound();
            if (User.IsInRole("Student") && enquiry.Email != User.Identity.Name)
                return Forbid();
            if (ModelState.IsValid)
            {
                enquiry.StudentName = model.StudentName;
                enquiry.Contact = model.Contact;
                enquiry.Course = model.Course;
                enquiry.Source = model.Source;
                enquiry.Priority = model.Priority;
                enquiry.Status = model.Status;
                await _context.SaveChangesAsync();
                TempData["Message"] = "Enquiry updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
