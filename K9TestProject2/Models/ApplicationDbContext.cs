using K9TestProject2.Models.ProductModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace K9TestProject2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("K9TestIgen1", throwIfV1Schema: false)
        {
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Egenskap> Egenskaps { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}