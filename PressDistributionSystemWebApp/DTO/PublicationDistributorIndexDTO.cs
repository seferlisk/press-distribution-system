using PressDistributionSystemWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class PublicationDistributorIndexDTO
    {
        public int PublicationId { get; set; }
        public string PublicationName { get; set; }
        public string PublicationIssue { get; set; }
        public ICollection<PublicationDistributorDTO> PublicationDistributors { get; set; }

    }

    public class PublicationDistributorDTO
    {

        public int Id { get; set; }

        public string DistributorName { get; set; }

        [Required]
        public int DistributorId { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
