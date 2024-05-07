using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Models
{
    public class Kiosk
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Distributor Distributor { get; set; }

        public ICollection<KioskPublication> KioskPublications { get; set; }

    }
}
