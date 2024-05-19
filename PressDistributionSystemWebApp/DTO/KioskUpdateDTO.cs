using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.DTO
{
    public class KioskUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        public string DistributorName { get; set; }


        //public ICollection<KioskPublication> KioskPublications { get; set; }

    }
}
