using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Models
{
    public class KioskPublication
    {
        public virtual int Id { get; set; }
        public virtual int Quantity { get; set; }


        public virtual Kiosk Kiosk { get; set; }

        public virtual PublicationDistributor PublicationDistributor { get; set; }

    }
}
