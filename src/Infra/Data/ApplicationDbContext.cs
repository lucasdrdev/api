using AppRequests.Domain.Products;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppRequests.Infra.Data;


public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //FluentAPI - modelando propriedades.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Utilizado para modelar a base da classe pai *identitydbcontext*
        base.OnModelCreating(builder);

        builder.Ignore<Notification>();

        builder.Entity<Product>()
            .Property(product => product.Name).IsRequired();
        builder.Entity<Product>()
            .Property(product => product.Description).HasMaxLength(255);
        builder.Entity<Category>()
            .Property(product => product.Name).IsRequired();
    }

    //Adicionando convenções.
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
       
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}
