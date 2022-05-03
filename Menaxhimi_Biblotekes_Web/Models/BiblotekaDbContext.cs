using Menaxhimi_Biblotekes.Models;
using Microsoft.EntityFrameworkCore;
namespace Menaxhimi_Biblotekes_Web.Models
{
    public class BiblotekaDbContext:DbContext
    {
        public BiblotekaDbContext(DbContextOptions options) :base(options)
        {

        }


        public DbSet<Roli> Roli { get; set; }
        public DbSet<Pjesemarresi> Pjesemarresi { get; set; }
        public DbSet<Libri> Libri { get; set; }
        public DbSet<Autori> Autori { get; set; }
        public DbSet<AutoriLibri> AutoriLibri { get; set; }
        public DbSet<Huazimi> Huazimi { get; set; }
        public DbSet<Kategoria> Kategoria { get; set; }
        public DbSet<KerkesatPerHuazim> KerkesatPerHuazim { get; set; }
    }
}
