using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteBoard.Entities;

namespace NoteBoard.DbContexts
{
    public class AuthDbContext : IdentityDbContext
    {
        public DbSet<Register> Registers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost;DataBase=Auth;Trusted_Connection=true;");
        }
    }
}
