using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Data;

namespace TravelAgencyApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.Bookings.Include(b => b.Tour).ToListAsync();
            return View(bookings);
        }

        public async Task<IActionResult> Details(int id)
        {
            var booking = await _context.Bookings.Include(b => b.Tour).FirstOrDefaultAsync(b => b.Id == id);
            if (booking == null) return NotFound();
            return View(booking);
        }
    }
}

