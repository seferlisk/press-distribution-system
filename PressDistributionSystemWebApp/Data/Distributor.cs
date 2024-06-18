using Microsoft.AspNetCore.Identity;

namespace PressDistributionSystemWebApp.Data
{
    public class Distributor
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IdentityUser? User { get; set; }
        public virtual List<Kiosk>? Kiosks { get; set; }
        public virtual List<PublicationDistributor>? PublicationDistributors { get; set; }
    }
}
