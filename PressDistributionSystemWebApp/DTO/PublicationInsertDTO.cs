using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class PublicationInsertDTO
    {
        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateOnly ShipmentDate { get; set; }

        [Required]
        public DateOnly ReturnDate { get; set; }
        
        [StringLength(60, MinimumLength = 1)]
        public string Issue { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
