using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using PressDistributionSystemWebApp.Data;
using PressDistributionSystemWebApp.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PressDistributionSystemWebApp.Controllers
{
    public class KioskDistributionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KioskDistributionController(ApplicationDbContext context)
        {
            _context = context;
        }


        /*
         * Handles GET requests to display the distribution data for a specific kiosk.
         */

        //Only users in the "Distributor" role can access this action.
        [Authorize(Roles = "Distributor")]
        public async Task<IActionResult> Index(int id, DateOnly? date = null)
        {

            var kiosk = await _context.Kiosks.SingleOrDefaultAsync(x => x.Id == id);
            if (kiosk == null)
            {
                return NotFound();
            }



            var vm = await LoadKioskDistributionDTO(kiosk, date);

            return View(vm);
        }

        /*
         * A private method to load and prepare the distribution data into a KioskDistributionDTO view model.
         */
        private async Task<KioskDistributionDTO> LoadKioskDistributionDTO(Kiosk kiosk, DateOnly? date, KioskDistributionDTO? vm = null)
        {
            if (vm == null)
                vm = new KioskDistributionDTO();

            if (date == null)
                date = DateOnly.FromDateTime(DateTime.Now);

            vm.Date = date.Value;

            vm.Kiosk = new KioskDTO()
            {
                Id = kiosk.Id,
                Name = kiosk.Name
            };

            //Retrieves the logged-in user's ID and their distributor ID.
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            vm.DistributorId = _context.Distributors.Single(s => s.User.Id == userId).Id;

            //Loads the existing distribution data for the kiosk.
            vm.Distribution = new List<KioskDistributionItemDTO>();           
           
            var kioskPublications = kiosk.KioskPublications?.Where(w => w.PublicationDistributor.Publication.ShipmentDate == date || w.PublicationDistributor.Publication.ReturnDate == date).ToList();            
          
            foreach (var kioskPublication in kioskPublications ?? new List<KioskPublication>())
            {

                var KioskPublicationDTO = new KioskDistributionItemDTO()
                {
                    Id = kioskPublication.Id,
                    PublicationName = kioskPublication.PublicationDistributor.Publication.Name,
                    PublicationDistributorId = kioskPublication.PublicationDistributor.Id,
                    Quantity = kioskPublication.Quantity,
                    ReturnedQuantity = kioskPublication.ReturnedQuantity,
                    PublicationIssue = kioskPublication.PublicationDistributor.Publication.Issue,
                    PublicationShipmentDate = kioskPublication.PublicationDistributor.Publication.ShipmentDate,
                    PublicationReturnDate = kioskPublication.PublicationDistributor.Publication.ReturnDate
                };

                vm.Distribution.Add(KioskPublicationDTO);
            }

            var distributorPublications = await _context.PublicationDistributors.Where(w => (w.Publication.ShipmentDate == date.Value || w.Publication.ReturnDate == date.Value) && w.Distributor.Id == vm.DistributorId).ToListAsync();
            //Retrieves additional publications for the distributor that are not yet associated with the kiosk.
            distributorPublications = distributorPublications.Where(x => !vm.Distribution.Any(y => y.PublicationDistributorId == x.Id)).ToList();

            foreach (var distributorPublication in distributorPublications)
            {

                var KioskPublicationDTO = new KioskDistributionItemDTO()
                {
                    Id = 0,
                    PublicationName = distributorPublication.Publication.Name,
                    PublicationDistributorId = distributorPublication.Id,
                    Quantity = null,
                    ReturnedQuantity = null,
                    PublicationIssue = distributorPublication.Publication.Issue,
                    PublicationShipmentDate = distributorPublication.Publication.ShipmentDate,
                    PublicationReturnDate = distributorPublication.Publication.ReturnDate

                };

                vm.Distribution.Add(KioskPublicationDTO);
            }

            //Calculates the remaining quantity for each publication.
            foreach (var item in vm.Distribution)
            {
                item.TotalQuantity = _context.PublicationDistributors.First(f => f.Id == item.PublicationDistributorId).Quantity;
                var usedQuantity = _context.KioskPublications.Where(w => w.PublicationDistributor.Id == item.PublicationDistributorId).Sum(s => s.Quantity);
                item.RemainingQuantity = item.TotalQuantity - usedQuantity + (item.Quantity ?? 0);
            }

            //Orders the distribution data by publication name and returns the view model.
            vm.Distribution = vm.Distribution.OrderBy(o => o.PublicationName).ToList();

            return vm;
        }


        /*
         * Handles POST requests to update the distribution data for a specific kiosk.
         */
        // POST: 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Distributor")]
        public async Task<IActionResult> Index(int id, KioskDistributionDTO vm, DateOnly? date = null)
        {
            var kiosk = await _context.Kiosks.SingleOrDefaultAsync(x => x.Id == id);
            if (kiosk == null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                if (kiosk.KioskPublications == null)
                    kiosk.KioskPublications = new List<KioskPublication>();

                //Iterates over the submitted distribution data.
                foreach (var publicationDTO in vm.Distribution ?? new List<KioskDistributionItemDTO>())
                {
                    //Updates existing publications or adds new ones as necessary.
                    var Kioskpublication = kiosk.KioskPublications.SingleOrDefault(x => x.Id == publicationDTO.Id && x.Id != 0);
                    if (Kioskpublication == null)
                    {
                        Kioskpublication = new KioskPublication();
                        kiosk.KioskPublications.Add(Kioskpublication);
                    }

                    //Updates each publication's properties.
                    Kioskpublication.Kiosk = kiosk;
                    Kioskpublication.PublicationDistributor = await _context.PublicationDistributors.SingleAsync(s => s.Id == publicationDTO.PublicationDistributorId);
                    Kioskpublication.Quantity = publicationDTO.Quantity ?? 0;
                    Kioskpublication.ReturnedQuantity = publicationDTO.ReturnedQuantity;
                    Kioskpublication.Id = publicationDTO.Id ?? 0;

                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Kiosks");
            }
            //If the model state is invalid, reloads the view model and returns the view for the user to correct the errors.
            vm = await LoadKioskDistributionDTO(kiosk, date);

            return View(vm);

        }


    }
}
