using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.Models.Data.MicroservicedbContext;

public partial class MicroservicedbContext : DbContext
{
    public MicroservicedbContext()
    {
    }

    public MicroservicedbContext(DbContextOptions<MicroservicedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("Conn");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("pk_customer");

            entity.ToTable("customer");

            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Customercontact)
                .HasMaxLength(15)
                .HasColumnName("customercontact");
            entity.Property(e => e.Customerlocation)
                .HasMaxLength(100)
                .HasColumnName("customerlocation");
            entity.Property(e => e.Customername)
                .HasMaxLength(255)
                .HasColumnName("customername");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
