using Microsoft.EntityFrameworkCore;
using UploadImage.Models;

namespace UploadImage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(x => x.Id);
            builder.Entity<Image>().Property(x => x.Name).IsRequired();
            builder.Entity<Image>().Property(x => x.Width).IsRequired();
            builder.Entity<Image>().Property(x => x.Height).IsRequired();
            builder.Entity<Image>().Property(x => x.ImageUrl).IsRequired();
        }

        public DbSet<Image> Images { get; set; }
    }
}
