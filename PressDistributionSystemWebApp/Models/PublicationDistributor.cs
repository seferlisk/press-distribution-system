using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Models
{
    public class PublicationDistributor
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        Distributor Distributor { get; set; }

        Publication Publication { get; set; }

        KioskPublication KioskPublication { get; set; }

    }
}
