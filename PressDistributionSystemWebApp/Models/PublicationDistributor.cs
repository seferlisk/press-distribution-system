using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Models
{
    public class PublicationDistributor
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }

        Distributor Distributor { get; set; }

        Publication Publication { get; set; }

        KioskPublication KioskPublication { get; set; }

    }
}
