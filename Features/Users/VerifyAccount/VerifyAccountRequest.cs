using System.ComponentModel.DataAnnotations;

namespace FoodRecipe.Features.Users.VerifyAccount
{
    public class VerifyAccountRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string OTP { get; set; }
    }
}
