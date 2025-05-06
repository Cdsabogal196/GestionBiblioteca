using System.Data.Entity;
using GestionDeBiblioteca.Models.Entities;

namespace GestionDeBiblioteca
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public AppDbContext() : base("name=DefaultConnection")
        {

        }

    }
}