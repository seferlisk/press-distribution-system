using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class KiosksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KiosksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kiosks
        [Authorize]
        public async Task<IActionResult> Index()
        {
            if(User.IsInRole("Agency"))
            {
                return View(await _context.Kiosks.ToListAsync());
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var distributorId = _context.Distributors.Single(s => s.User.Id == userId).Id;

            return View(await _context.Kiosks.Where(w=> w.Distributor.Id == distributorId).ToListAsync());
        }

        // GET: Kiosks/Details/5
        [Authorize]
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
        [Authorize(Roles = "Agency")]
        public IActionResult Create()
        {
            var kiosk = new KioskInsertDTO();
            kiosk.Distributors = GetDistributors();

            return View(kiosk);
        }


        public List<SelectListItem> GetDistributors()
        {
            var distributors = new List<SelectListItem>();


            distributors.AddRange(_context.Distributors.OrderBy(o => o.Name).Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }));


            return distributors;
        }

        // POST: Kiosks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Create(KioskInsertDTO kiosk)
        {
            if (ModelState.IsValid)
            {
                var kioskToInsert = new Kiosk();
                kioskToInsert.Name = kiosk.Name;
                kioskToInsert.Distributor = _context.Distributors.Where(w => w.Id == kiosk.DistributorId).FirstOrDefault();
                _context.Add(kioskToInsert);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kiosk);
        }

        // GET: Kiosks/Edit/5
        [Authorize]
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
            var kioskVM = new KioskUpdateDTO()
            {
                Name = kiosk.Name,
                Id = kiosk.Id
            };


            return View(kioskVM);
        }

        // POST: Kiosks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, KioskUpdateDTO kiosk)
        {
            if (id != kiosk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var kioskToUpdate = await _context.Kiosks.FindAsync(id);
                    if (kioskToUpdate == null)
                    {
                        return NotFound();
                    }
                    kioskToUpdate.Name = kiosk.Name;                    
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
        [Authorize]
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
        [Authorize]
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
