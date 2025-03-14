using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PressDistributionSystemWebApp.Data;
using PressDistributionSystemWebApp.DTO;
using PressDistributionSystemWebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PressDistributionAPI.Controllers
{
    [Route("api/distributors")]
    [ApiController]
    public class DistributorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DistributorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/distributors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Distributor>>> GetDistributors()
        {
            return await _context.Distributors.ToListAsync();
        }

        // GET: api/distributors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Distributor>> GetDistributor(int id)
        {
            var distributor = await _context.Distributors.FindAsync(id);

            if (distributor == null)
            {
                return NotFound();
            }

            return distributor;
        }

        // POST: api/distributors
        [HttpPost]
        public async Task<ActionResult<Distributor>> CreateDistributor(DistributorInsertDTO distributorDto)
        {
            var distributor = new Distributor
            {
                Name = distributorDto.Name,
                User = await _context.Users.FirstOrDefaultAsync(f => f.Id == distributorDto.DistributorUserId)
            };

            _context.Distributors.Add(distributor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDistributor), new { id = distributor.Id }, distributor);
        }

        // PUT: api/distributors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDistributor(int id, DistributorUpdateDTO distributorDto)
        {
            if (id != distributorDto.Id)
            {
                return BadRequest();
            }

            var distributor = await _context.Distributors.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }

            distributor.Name = distributorDto.Name;
            distributor.User = await _context.Users.FirstOrDefaultAsync(f => f.Id == distributorDto.DistributorUserId);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Distributors.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/distributors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistributor(int id)
        {
            var distributor = await _context.Distributors.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }

            _context.Distributors.Remove(distributor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
