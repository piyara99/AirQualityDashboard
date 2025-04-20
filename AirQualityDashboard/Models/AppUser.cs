using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AirQualityDashboard.Models
{
    public class AppUser : IdentityUser
    {

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = "Default Name";
    }

}

