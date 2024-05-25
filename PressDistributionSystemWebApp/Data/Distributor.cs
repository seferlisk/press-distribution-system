using Microsoft.AspNetCore.Identity;

namespace PressDistributionSystemWebApp.Data
{
    public class Distributor
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<IdentityUser>? Users { get; set; }
        public virtual ICollection<Kiosk>? Kiosks { get; set; }
        public virtual ICollection<PublicationDistributor>? PublicationDistributors { get; set; }
    }
}
