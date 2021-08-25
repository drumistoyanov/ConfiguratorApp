namespace ConfiguratorApp.DataAccessLayer.DataAccess
{
    using ConfiguratorApp.DataAccessLayer.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class ConfiguratorAppDbContext : DbContext
    {
        public ConfiguratorAppDbContext(DbContextOptions<ConfiguratorAppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<ComputerComponents> ComputerComponents { get; set; }
        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            //ConfigureUserIdentityRelations(builder);

            System.Collections.Generic.IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableEntityType> entityTypes = builder.Model.GetEntityTypes();

            // Disable cascade delete
            System.Collections.Generic.IEnumerable<Microsoft.EntityFrameworkCore.Metadata.IMutableForeignKey> foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableForeignKey foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<Component>(entity =>
            {
                entity.HasOne<Manufacturer>(d => d.Manufacturer).WithMany(p => p.Components).HasForeignKey(d => d.ManufacturerId);
                entity.ToTable("Components");
            });
            builder.Entity<Manufacturer>(entity =>
            {
                entity.HasMany(d => d.Components).WithOne(p => p.Manufacturer).HasForeignKey(d => d.ManufacturerId);

                entity.ToTable("Manufacturers");
            });

            builder.Entity<ComputerComponents>()
     .HasKey(cc => new { cc.ComponentId, cc.ComputerId });
            builder.Entity<ComputerComponents>()
                .HasOne(cc => cc.Computer)
                .WithMany(b => b.ComputerComponents)
                .HasForeignKey(cc => cc.ComputerId);
            builder.Entity<ComputerComponents>()
                .HasOne(cc => cc.Component)
                .WithMany(c => c.ComputerComponents)
                .HasForeignKey(cc => cc.ComponentId);

        }
    }
}
