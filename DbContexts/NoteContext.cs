using Microsoft.EntityFrameworkCore;
using NoteBoard.Entities;

namespace NoteBoard.DbContexts
{
    public class NoteContext : DbContext
    {
       
            public DbSet<Note> Notes { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder builder)
            {
                builder.UseSqlServer("Server=localhost;DataBase=Notes;Trusted_Connection=true;");
            }
        }
    }

