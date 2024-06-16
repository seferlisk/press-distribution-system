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

            var publication = await _context.Publications.SingleOrDefaultAsync(x => x.Id == id);
            if (publication == null)
            {
                return NotFound();
            }

            var model = new PublicationDistributionIndexDTO();
            model.Publication = new PublicationDistributionPublicationDTO()
            {
                Id = publication.Id,
                Name = publication.Name,
                Issue = publication.Issue,
                Quantity = publication.Quantity

            };
            model.PublicationDistributors = new List<PublicationDistributionDistributionDTO>();



            foreach (var publicationDist in publication.PublicationDistributors ?? new List<PublicationDistributor>())
            {

                var publicationDistributor = new PublicationDistributionDistributionDTO()
                {
                    DistributorName = publicationDist.Distributor.Name,
                    DistributorId = publicationDist.Distributor.Id,
                    Quantity = publicationDist.Quantity,
                    Id = publicationDist.Id

                };

                model.PublicationDistributors.Add(publicationDistributor);
            }

            var distributors = await _context.Distributors.ToListAsync();

            distributors = distributors.Where(x => !model.PublicationDistributors.Any(y => y.DistributorId == x.Id)).ToList();

            foreach (var distributor in distributors)
            {


                var publicationDistributor = new PublicationDistributionDistributionDTO()
                {
                    DistributorName = distributor.Name,
                    DistributorId = distributor.Id,
                    Quantity = 0
                };

                model.PublicationDistributors.Add(publicationDistributor);
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
            var publication = await _context.Publications.SingleOrDefaultAsync(x => x.Id == id);
            if (publication == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                if (publication.PublicationDistributors == null)
                    publication.PublicationDistributors = new List<PublicationDistributor>();

                publication.PublicationDistributors = publication.PublicationDistributors.Where(w => publicationDistributionDTO.PublicationDistributors.Any(a => a.Id == w.Id)).ToList();


                foreach (var item in publicationDistributionDTO.PublicationDistributors)
                {
                    var publicationDistributor = publication.PublicationDistributors.SingleOrDefault(x => x.Id == item.Id);
                    if (publicationDistributor == null)
                        publicationDistributor = new PublicationDistributor();

                    publicationDistributor.Publication = publication;
                    publicationDistributor.Distributor = await _context.Distributors.Where(w => w.Id == item.DistributorId).SingleAsync();
                    publicationDistributor.Quantity = item.Quantity;
                    publicationDistributor.Id = item.Id ?? 0;
                    publication.PublicationDistributors.Add(publicationDistributor);
                }




                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { id = publication.Id });
            }

            return View(publicationDistributionDTO);
        }

      
    }
}
