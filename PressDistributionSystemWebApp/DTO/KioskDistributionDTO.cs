using Microsoft.AspNetCore.Mvc.Rendering;
using PressDistributionSystemWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class KioskDistributionDTO
    {
        public KioskDTO? Kiosk { get; set; }

        [Required]
        public int DistributorId { get; set; }


        [Required]
        public List<KioskDistributionItemDTO> Distribution { get; set; }

        public DateOnly Date { get; set; }
    }

    public class KioskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class KioskDistributionItemDTO
    {
        public int? Id { get; set; }

        public string? PublicationName { get; set; }

        public string? PublicationIssue { get; set; }

        [Required]
        public int? PublicationDistributorId { get; set; }

        [Required]
        public int? Quantity { get; set; }
        public int RemainingQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public int? ReturnedQuantity { get; set; }


    }
}
