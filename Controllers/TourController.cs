using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Data;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Controllers
{
    public class TourController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public TourController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Manage()
        {
            var tours = await _context.Tours.Include(t => t.Profile).ToListAsync();
            return View(tours);
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.Profiles = await _context.Profiles.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tour tour, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.Combine(_environment.WebRootPath, "uploads", image.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                tour.ImagePath = "/uploads/" + image.FileName;
            }

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            ViewBag.Profiles = await _context.Profiles.ToListAsync();
            return View(tour);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Tour tour, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.Combine(_environment.WebRootPath, "uploads", image.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                tour.ImagePath = "/uploads/" + image.FileName;
            }

            _context.Update(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Manage));
        }
    }
}

