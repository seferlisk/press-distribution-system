using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PressDistributionSystemWebApp.Data;
using PressDistributionSystemWebApp.DTO;

namespace PressDistributionSystemWebApp.Controllers
{
    public class PublicationDistributorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationDistributorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publication = _context.Publications.Single(x => x.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            var model = new PublicationDistributionIndexDTO();
            model.Publication.Id = publication.Id;
            model.Publication.Name = publication.Name;
            model.Publication.Issue = publication.Issue;
            model.Distributors = new List<Distributor>();
            var distributorList = await _context.Distributors.ToListAsync();
            foreach (var distributor in distributorList)
            {
                var publicationDistributor = new PublicationDistributor();
                publicationDistributor.Id = distributor.Id;
                publicationDistributor.Distributor.Name = distributor.Name;
                publicationDistributor.Quantity = 0;
                model.Distributors.Add(publicationDistributor);
            }
            return View(model);
        }

        // POST: 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, PublicationDistributionIndexDTO publicationDistributionDTO)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in publicationDistributionDTO.Distributors)
                {
                    var publicationDistributor = new Distributor();
                    {   
                        Id = id,
                        Name = item.Name,
                        Quantity = item.Quantity
                    };

                    _context.Add(publicationDistributor);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = publicationDistributionDTO.PublicationId });

                //_context.Add(publicationDistributor);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Publication));
            }
            return View(publicationDistributionDTO);
        }

        // GET:
        //public async Task<IActionResult> Index(int id)
        //{
        //    var publication = _context.Publications.Single(x => x.Id == id);
        //    var model = new PublicationDistributionIndexDTO();
        //    model.PublicationId = publication.Id;
        //    model.PublicationName = publication.Name;
        //    model.PublicationIssue = publication.Issue;
        //    model.PublicationDistributors = new List<PublicationDistributorDTO>();
        //    var distributorList = await _context.Distributors.ToListAsync();
        //    foreach (var distributor in distributorList)
        //    {
        //        var publicationDistributor = new PublicationDistributorDTO();
        //        publicationDistributor.DistributorId = distributor.Id;
        //        publicationDistributor.DistributorName = distributor.Name;
        //        publicationDistributor.Quantity = 0;
        //        model.PublicationDistributors.Add(publicationDistributor);
        //    }            
        //    return View(model);
        //}       

        //// POST: 
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index(int id, PublicationDistributionIndexDTO publicationDistributionDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var item in publicationDistributionDTO.PublicationDistributors)
        //        {
        //            var publicationDistributor = new PublicationDistributorDTO
        //            {
        //                Id = id,
        //                DistributorName = item.DistributorName,
        //                Quantity = item.Quantity
        //            };

        //            _context.Add(publicationDistributor);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index), new { id = publicationDistributionDTO.PublicationId });

        //        //_context.Add(publicationDistributor);
        //        //await _context.SaveChangesAsync();
        //        //return RedirectToAction(nameof(Publication));
        //    }
        //    return View(publicationDistributionDTO);
        //}
    }
}
