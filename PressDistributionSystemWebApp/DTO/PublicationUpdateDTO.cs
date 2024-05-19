using PressDistributionSystemWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class PublicationUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateOnly ShipmentDate { get; set; }

        [Required]
        public DateOnly ReturnDate { get; set; }

        [StringLength(60, MinimumLength = 1)]
        public string Issue { get; set; }

        //public ICollection<PublicationDistributor> PublicationDistributors { get; set; }
    }
}
