using K9TestProject3.Fantastic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace K9TestProject3.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("K9Test1", throwIfV1Schema: false)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ColorAttribute> ColorAttributes { get; set; }
        public DbSet<SizeAttribute> SizeAttributes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}