using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Data
{
    public class PublicationDistributor
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }

        public Distributor Distributor { get; set; }

        public Publication Publication { get; set; }

        public KioskPublication KioskPublication { get; set; }

    }
}
