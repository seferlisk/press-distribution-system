using Microsoft.AspNetCore.Mvc.Rendering;
using PressDistributionSystemWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PressDistributionSystemWebApp.DTO
{
    public class KioskInsertDTO
    {
        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The DistributorId field is required.")]
        public int DistributorId { get; set; }
        public List<SelectListItem>? Distributors { get; set; }

    }
}
    