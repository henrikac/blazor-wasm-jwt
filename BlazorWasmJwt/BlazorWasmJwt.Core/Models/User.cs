using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorWasmJwt.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Username { get; set; }

        [Required]
        [MaxLength(40)]
        public string NormalizedUsername { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string NormalizedEmail { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}