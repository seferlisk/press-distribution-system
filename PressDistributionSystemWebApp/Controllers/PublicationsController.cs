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
    public class PublicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Publications
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Publications.ToListAsync());
        }

        // GET: Publications/Details/5
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publications/Create
        [Authorize(Roles = "Agency")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Create(PublicationInsertDTO publication)
        {
            if (ModelState.IsValid)
            {
                var insertedPublication = new Publication();                
                insertedPublication.Name = publication.Name;
                insertedPublication.ShipmentDate = publication.ShipmentDate;
                insertedPublication.ReturnDate = publication.ReturnDate;
                insertedPublication.Issue = publication.Issue;
                insertedPublication.Quantity = publication.Quantity;
                _context.Add(insertedPublication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publication);
        }

        // GET: Publications/Edit/5
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publications.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            var updatedPublication = new PublicationUpdateDTO()
            {
                Id = publication.Id, 
                Name = publication.Name,
                ShipmentDate = publication.ShipmentDate,
                ReturnDate = publication.ReturnDate,
                Issue = publication.Issue,
                Quantity = publication.Quantity
            };

            return View(updatedPublication);
        }

        // POST: Publications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Edit(int id, PublicationUpdateDTO publication)
        {
            if (id != publication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var publicationToUpdate = await _context.Publications.FindAsync(id);
                    if (publicationToUpdate == null)
                    {
                        return NotFound();
                    }
                    publicationToUpdate.Name = publication.Name;
                    publicationToUpdate.ShipmentDate = publication.ShipmentDate;
                    publicationToUpdate.ReturnDate = publication.ReturnDate;
                    publicationToUpdate.Issue = publication.Issue;   
                    publicationToUpdate.Quantity = publication.Quantity;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationExists(publication.Id))
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
            return View(publication);
        }

        // GET: Publications/Delete/5
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = await _context.Publications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Agency")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publication = await _context.Publications.FindAsync(id);
            if (publication != null)
            {
                _context.Publications.Remove(publication);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationExists(int id)
        {
            return _context.Publications.Any(e => e.Id == id);
        }
    }
}
