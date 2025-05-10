using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Data;

namespace TravelAgencyApp.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var feedbacks = await _context.Feedbacks.ToListAsync();
            return View(feedbacks);
        }
    }
}

