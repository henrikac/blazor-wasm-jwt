using BlazorWasmJwt.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmJwt.DAL
{
    public class BlazorJwtContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BlazorJwtContext(DbContextOptions<BlazorJwtContext> options) : base(options)
        {
        }
    }
}