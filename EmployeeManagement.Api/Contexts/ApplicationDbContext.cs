using System.Reflection;
using EmployeeManagement.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Employee>? Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}