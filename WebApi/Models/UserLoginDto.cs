using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }
}
