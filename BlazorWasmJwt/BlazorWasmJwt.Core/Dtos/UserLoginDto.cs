using System.ComponentModel.DataAnnotations;

namespace BlazorWasmJwt.Core.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}