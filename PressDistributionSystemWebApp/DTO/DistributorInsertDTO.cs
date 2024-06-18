using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PressDistributionSystemWebApp.DTO
{
    public class DistributorInsertDTO
    {
        [Required, StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string? DistributorUserId { get; set; }

        public List<SelectListItem>? Users { get; set; }

    }
}
