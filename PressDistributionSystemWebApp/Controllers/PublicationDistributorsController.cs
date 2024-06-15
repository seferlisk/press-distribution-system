using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PressDistributionSystemWebApp.Data;

namespace PressDistributionSystemWebApp.Controllers
{
    public class PublicationDistributorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationDistributorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PublicationDistributors
        public async Task<IActionResult> Index()
        {
            return View(await _context.PublicationDistributors.ToListAsync());
        }

        // GET: PublicationDistributors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicationDistributor = await _context.PublicationDistributors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicationDistributor == null)
            {
                return NotFound();
            }

            return View(publicationDistributor);
        }

        // GET: PublicationDistributors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PublicationDistributors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quantity")] PublicationDistributor publicationDistributor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publicationDistributor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicationDistributor);
        }

        // GET: PublicationDistributors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicationDistributor = await _context.PublicationDistributors.FindAsync(id);
            if (publicationDistributor == null)
            {
                return NotFound();
            }
            return View(publicationDistributor);
        }

        // POST: PublicationDistributors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quantity")] PublicationDistributor publicationDistributor)
        {
            if (id != publicationDistributor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publicationDistributor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationDistributorExists(publicationDistributor.Id))
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
            return View(publicationDistributor);
        }

        // GET: PublicationDistributors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicationDistributor = await _context.PublicationDistributors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publicationDistributor == null)
            {
                return NotFound();
            }

            return View(publicationDistributor);
        }

        // POST: PublicationDistributors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicationDistributor = await _context.PublicationDistributors.FindAsync(id);
            if (publicationDistributor != null)
            {
                _context.PublicationDistributors.Remove(publicationDistributor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationDistributorExists(int id)
        {
            return _context.PublicationDistributors.Any(e => e.Id == id);
        }
    }
}
