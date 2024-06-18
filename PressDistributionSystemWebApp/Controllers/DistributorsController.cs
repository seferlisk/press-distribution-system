using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PressDistributionSystemWebApp.Data;
using PressDistributionSystemWebApp.DTO;
using PressDistributionSystemWebApp.Models;

namespace PressDistributionSystemWebApp.Controllers
{
    public class DistributorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DistributorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Distributors
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Distributors.ToListAsync());
        }

        // GET: Distributors/Details/5
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributor = await _context.Distributors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (distributor == null)
            {
                return NotFound();
            }

            return View(distributor);
        }

        // GET: Distributors/Create
        [Authorize(Roles = "Agency")]
        public IActionResult Create()
        {

            var distributor = new DistributorInsertDTO();
            distributor.Users = GetUsers();

            return View(distributor);
        }

        // POST: Distributors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Create(DistributorInsertDTO distributor)
        {
            if (ModelState.IsValid)
            {
                var insertedDistributor = new Distributor();
                insertedDistributor.Name = distributor.Name;
                insertedDistributor.User = _context.Users.FirstOrDefault(f => f.Id == distributor.DistributorUserId);
                _context.Add(insertedDistributor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            distributor.Users = GetUsers();

            return View(distributor);
        }

        // GET: Distributors/Edit/5
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributor = await _context.Distributors.FindAsync(id);
            if (distributor == null)
            {
                return NotFound();
            }

            var updatedDistributor = new DistributorUpdateDTO();
            updatedDistributor.Name = distributor.Name;
            updatedDistributor.DistributorUserId = distributor.User?.Id; 
            updatedDistributor.Users = GetUsers();
            return View(updatedDistributor);
        }

        public List<SelectListItem> GetUsers()
        {
            var distributors = new List<SelectListItem>();


            distributors.AddRange(_context.Users.OrderBy(o => o.UserName).Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.UserName
            }));


            return distributors;
        }

        // POST: Distributors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Edit(int id, DistributorUpdateDTO distributor)
        {
            if (id != distributor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var distributorToUpdate = await _context.Distributors.FindAsync(id);
                    if (distributorToUpdate == null)
                    {
                        return NotFound();
                    }
                    distributorToUpdate.Name = distributor.Name;                    
                    distributorToUpdate.User = _context.Users.FirstOrDefault(f => f.Id == distributor.DistributorUserId);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistributorExists(distributor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            distributor.Users = GetUsers();

            return View(distributor);
        }

        // GET: Distributors/Delete/5
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var distributor = await _context.Distributors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (distributor == null)
            {
                return NotFound();
            }

            return View(distributor);
        }

        // POST: Distributors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var distributor = await _context.Distributors.FindAsync(id);
            if (distributor != null)
            {
                _context.Distributors.Remove(distributor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistributorExists(int id)
        {
            return _context.Distributors.Any(e => e.Id == id);
        }
    }
}
