using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Data
{
    public class PublicationDistributor
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }

        public virtual Distributor Distributor { get; set; }

        public virtual Publication Publication { get; set; }

    }
}
