using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PressDistributionSystemWebApp.Data;
using PressDistributionSystemWebApp.Models;

namespace PressDistributionAPI.Controllers
{
    [Route("api/publications")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PublicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publications = await _context.Publications.ToListAsync();
            return Ok(publications); // Returns JSON response
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
            if (publication == null) return NotFound();
            return Ok(publication);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Publication publication)
        {
            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = publication.Id }, publication);
        }
    }
}
