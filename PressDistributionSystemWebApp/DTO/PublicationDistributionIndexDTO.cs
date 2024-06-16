using PressDistributionSystemWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class PublicationDistributionIndexDTO
    {

        public PublicationDistributionPublicationDTO Publication { get; set; }

        [Required]

        public List<PublicationDistributionDistributionDTO> PublicationDistributors { get; set; }

    }

    public class PublicationDistributionPublicationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Issue { get; set; }
        public int Quantity { get; set; }
    }

    public class PublicationDistributionDistributionDTO
    {
        public int? Id { get; set; }

        [Required]
        public string? DistributorName { get; set; }

        [Required]
        public int DistributorId { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
