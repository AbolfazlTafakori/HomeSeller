using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TafakoriHomeSeller.Models;

namespace TafakoriHomeSeller.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> ApplicationUser { get; set; }
        public DbSet<EstateModel> Estate { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<FavouriteModel> Favourite { get; set; }
    }
}