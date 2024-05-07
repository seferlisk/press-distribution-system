using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Models
{
    public class KioskPublication
    {
        public int Id { get; set; }
        public int Quantity { get; set; }


        public Kiosk Kiosk { get; set; }

        public PublicationDistributor PublicationDistributor { get; set; }

    }
}
