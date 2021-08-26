using System.ComponentModel.DataAnnotations;

namespace BlazorWasmJwt.Core.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(40)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}