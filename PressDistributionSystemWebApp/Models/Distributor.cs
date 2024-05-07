using Microsoft.AspNetCore.Identity;

namespace PressDistributionSystemWebApp.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<IdentityUser> Users { get; set; }
        public ICollection<Kiosk> Kiosks { get; set; }
        public ICollection<PublicationDistributor> PublicationDistributors { get; set; }
    }
}
