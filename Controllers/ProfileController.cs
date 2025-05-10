using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelAgencyApp.Data;
using TravelAgencyApp.Models;

namespace TravelAgencyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var profiles = await _context.Profiles.ToListAsync();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();
            return Ok(profile);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Profile profile)
        {
            if (id != profile.Id) return BadRequest();

            _context.Update(profile);
            await _context.SaveChangesAsync();
            return Ok(profile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null) return NotFound();

            _context.Remove(profile);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

