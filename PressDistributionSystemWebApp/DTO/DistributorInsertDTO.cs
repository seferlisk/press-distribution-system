using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class DistributorInsertDTO
    {
        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        //public ICollection<IdentityUser> Users { get; set; }
        //public ICollection<Kiosk> Kiosks { get; set; }
        //public ICollection<PublicationDistributor> PublicationDistributors { get; set; }
    }
}
