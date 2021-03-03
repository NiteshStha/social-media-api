using System.ComponentModel.DataAnnotations;

namespace SocialMediaServer.Models.Users
{
    public class SignInModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}