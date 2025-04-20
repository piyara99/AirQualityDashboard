using System.ComponentModel.DataAnnotations;

namespace AirQualityDashboard.ViewModels
{
    public class UserManagementViewModel
    {
        public string UserId { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
