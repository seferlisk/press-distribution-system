using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PressDistributionSystemWebApp.Data;
using PressDistributionSystemWebApp.Models;

namespace PressDistributionSystemWebApp.Controllers
{
    public class KiosksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KiosksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kiosks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kiosks.ToListAsync());
        }

        // GET: Kiosks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiosk = await _context.Kiosks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kiosk == null)
            {
                return NotFound();
            }

            return View(kiosk);
        }

        // GET: Kiosks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kiosks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Kiosk kiosk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kiosk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kiosk);
        }

        // GET: Kiosks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiosk = await _context.Kiosks.FindAsync(id);
            if (kiosk == null)
            {
                return NotFound();
            }
            return View(kiosk);
        }

        // POST: Kiosks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Kiosk kiosk)
        {
            if (id != kiosk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kiosk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KioskExists(kiosk.Id))
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
            return View(kiosk);
        }

        // GET: Kiosks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiosk = await _context.Kiosks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kiosk == null)
            {
                return NotFound();
            }

            return View(kiosk);
        }

        // POST: Kiosks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kiosk = await _context.Kiosks.FindAsync(id);
            if (kiosk != null)
            {
                _context.Kiosks.Remove(kiosk);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KioskExists(int id)
        {
            return _context.Kiosks.Any(e => e.Id == id);
        }
    }
}
