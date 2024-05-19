using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class DistributorUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        //public ICollection<IdentityUser> Users { get; set; }
        //public ICollection<KioskInsertDTO> Kiosks { get; set; }
        //public ICollection<PublicationDistributor> PublicationDistributors { get; set; }
    }
}
