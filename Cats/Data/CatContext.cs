using Cats.Models;
using Microsoft.EntityFrameworkCore;

namespace Cats.Data
{
    public class CatContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CatDb;Integrated Security=True;");
        }

    }
}
