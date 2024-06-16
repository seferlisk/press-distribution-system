using PressDistributionSystemWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class PublicationDistributionDTO
    {

        public PublicationDTO Publication { get; set; }

        [Required]

        public List<PublicationDistributionItemDTO> Distribution { get; set; }

    }

    public class PublicationDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Issue { get; set; }
        public int Quantity { get; set; }
    }

    public class PublicationDistributionItemDTO
    {
        public int? PublicationDistributorId { get; set; }

        public string? DistributorName { get; set; }

        [Required]
        public int DistributorId { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
