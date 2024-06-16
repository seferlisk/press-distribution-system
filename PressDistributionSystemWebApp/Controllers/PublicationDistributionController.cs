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
    public class PublicationDistributionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicationDistributionController(ApplicationDbContext context)
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

            var vm = await LoadPublicationDistributionViewModel(publication);
            return View(vm);
        }

        private async Task<PublicationDistributionDTO> LoadPublicationDistributionViewModel(Publication publication, PublicationDistributionDTO vm = null)
        {
            if (vm == null)
                vm = new PublicationDistributionDTO();

            vm.Publication = new PublicationDTO()
            {
                Id = publication.Id,
                Name = publication.Name,
                Issue = publication.Issue,
                Quantity = publication.Quantity

            };
            vm.Distribution = new List<PublicationDistributionItemDTO>();



            foreach (var publicationDist in publication.PublicationDistributors ?? new List<PublicationDistributor>())
            {

                var publicationDistributor = new PublicationDistributionItemDTO()
                {
                    DistributorName = publicationDist.Distributor.Name,
                    DistributorId = publicationDist.Distributor.Id,
                    Quantity = publicationDist.Quantity,
                    PublicationDistributorId = publicationDist.Id

                };

                vm.Distribution.Add(publicationDistributor);
            }

            var distributors = await _context.Distributors.ToListAsync();

            distributors = distributors.Where(x => !vm.Distribution.Any(y => y.DistributorId == x.Id)).ToList();

            foreach (var distributor in distributors)
            {


                var publicationDistributor = new PublicationDistributionItemDTO()
                {
                    DistributorName = distributor.Name,
                    DistributorId = distributor.Id,
                    Quantity = 0
                };

                vm.Distribution.Add(publicationDistributor);
            }

            return vm;
        }

        // POST: 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, PublicationDistributionDTO vm)
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

                foreach (var publicationVm in vm.Distribution)
                {
                    var publicationDistributor = publication.PublicationDistributors.SingleOrDefault(x => x.Id == publicationVm.PublicationDistributorId && x.Id != 0);
                    if (publicationDistributor == null)
                    {
                        publicationDistributor = new PublicationDistributor();
                        publication.PublicationDistributors.Add(publicationDistributor);
                    }

                    publicationDistributor.Publication = publication;
                    publicationDistributor.Distributor = await _context.Distributors.Where(w => w.Id == publicationVm.DistributorId).SingleAsync();
                    publicationDistributor.Quantity = publicationVm.Quantity;
                    publicationDistributor.Id = publicationVm.PublicationDistributorId ?? 0;
                }


                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Publications");
            }

            vm = await LoadPublicationDistributionViewModel(publication, vm);
            return View(vm);
        }


    }
}
