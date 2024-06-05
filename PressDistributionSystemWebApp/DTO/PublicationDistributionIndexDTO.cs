using PressDistributionSystemWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class PublicationDistributionIndexDTO
    {
        [Required, StringLength(60, MinimumLength = 1)]
        public Publication? Publication { get; set; }

        [Required]
        public List<Distributor> Distributors { get; set; } 
        
    }
    //public class PublicationDistributionIndexDTO
    //{
    //    public int PublicationId { get; set; }
    //    public string PublicationName { get; set; }
    //    public string PublicationIssue { get; set; }
    //    public ICollection<PublicationDistributorDTO> PublicationDistributors { get; set; }
           

    //}

    //public class PublicationDistributorDTO
    //{

    //    public int Id { get; set; }

    //    public string? DistributorName { get; set; }

    //    [Required]
    //    public int DistributorId { get; set; }

    //    [Required]
    //    public int Quantity { get; set; }

    //}
}
