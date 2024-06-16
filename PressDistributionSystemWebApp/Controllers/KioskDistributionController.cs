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
    public class KioskDistributionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KioskDistributionController(ApplicationDbContext context)
        {
            _context = context;
        }

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

            vm.DistributorId = _context.Distributors.First().Id;



            vm.Distribution = new List<KioskDistributionItemDTO>();

            var kioskPublications = kiosk.KioskPublications?.Where(w => w.PublicationDistributor.Publication.ShipmentDate == date).ToList();

            foreach (var kioskPublication in kioskPublications ?? new List<KioskPublication>())
            {

                var KioskPublicationDTO = new KioskDistributionItemDTO()
                {
                    Id = kioskPublication.Id,
                    PublicationName = kioskPublication.PublicationDistributor.Publication.Name,
                    PublicationDistributorId = kioskPublication.PublicationDistributor.Id,
                    Quantity = kioskPublication.Quantity,
                    ReturnedQuantity = kioskPublication.ReturnedQuantity,
                    PublicationIssue = kioskPublication.PublicationDistributor.Publication.Issue
                };

                vm.Distribution.Add(KioskPublicationDTO);
            }

            var distributorPublications = await _context.PublicationDistributors.Where(w => w.Publication.ShipmentDate == date.Value && w.Distributor.Id == vm.DistributorId).ToListAsync();
            //filter out the publications that are already in the list
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

                };

                vm.Distribution.Add(KioskPublicationDTO);
            }

            //Calculate the remaining quantity
            foreach (var item in vm.Distribution)
            {
                item.TotalQuantity = _context.PublicationDistributors.First(f => f.Id == item.PublicationDistributorId).Quantity;
                var usedQuantity = _context.KioskPublications.Where(w => w.PublicationDistributor.Id == item.PublicationDistributorId).Sum(s => s.Quantity);
                item.RemainingQuantity = item.TotalQuantity - usedQuantity + (item.Quantity ?? 0);
            }


            vm.Distribution = vm.Distribution.OrderBy(o => o.PublicationName).ToList();

            return vm;
        }


        // POST: 
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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


                foreach (var publicationDTO in vm.Distribution ?? new List<KioskDistributionItemDTO>())
                {
                    var Kioskpublication = kiosk.KioskPublications.SingleOrDefault(x => x.Id == publicationDTO.Id && x.Id != 0);
                    if (Kioskpublication == null)
                    {
                        Kioskpublication = new KioskPublication();
                        kiosk.KioskPublications.Add(Kioskpublication);
                    }

                    Kioskpublication.Kiosk = kiosk;
                    Kioskpublication.PublicationDistributor = await _context.PublicationDistributors.SingleAsync(s => s.Id == publicationDTO.PublicationDistributorId);
                    Kioskpublication.Quantity = publicationDTO.Quantity ?? 0;
                    Kioskpublication.ReturnedQuantity = publicationDTO.ReturnedQuantity;
                    Kioskpublication.Id = publicationDTO.Id ?? 0;

                }




                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Kiosks");
            }

            vm = await LoadKioskDistributionDTO(kiosk, date);

            return View(vm);

        }


    }
}
