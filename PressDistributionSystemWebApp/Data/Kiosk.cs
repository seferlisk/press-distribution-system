using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.Data
{
    public class Kiosk
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Distributor? Distributor { get; set; }

        public virtual List<KioskPublication>? KioskPublications { get; set; }

    }
}
