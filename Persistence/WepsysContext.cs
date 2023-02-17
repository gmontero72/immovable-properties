using Microsoft.EntityFrameworkCore;
using Persistence.Models;


namespace Persistence
{
    public sealed class WepsysContext : DbContext
    {
        /// <summary>
        /// Indicates which is the default schema for portal
        /// </summary>
        public const string DefaultSchema = "RINovus";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public WepsysContext(DbContextOptions<WepsysContext> options) :
            base(options)
        {
            Owners = Set<ImmovableOwnerDb>();
            Properties = Set<ImmovablePropertyDb>();
        }

        /// <inheritdoc cref="DbContext.OnModelCreating"/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DefaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WepsysContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ImmovableOwnerDb>()
            .HasMany(x => x.PropertiesList)
            .WithOne(x => x.OwnerDb)
            .HasForeignKey(x => x.ImmovableOwnerClassId)
            .OnDelete(DeleteBehavior.Cascade);

        }



        public DbSet<ImmovableOwnerDb> Owners { get; set; }

        public DbSet<ImmovablePropertyDb> Properties { get; set; }

    }
}
