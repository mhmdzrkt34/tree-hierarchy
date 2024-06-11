using binaryTree.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace binaryTree.data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasMany(item => item.subCategories).WithOne(i => i.parentCategory).HasForeignKey(j => j.parent_id).OnDelete(DeleteBehavior.Restrict);
        }

    }



}
