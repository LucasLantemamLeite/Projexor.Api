using Microsoft.EntityFrameworkCore;
using Projexor.Models;

namespace Projexor.Data.Context;

public class AppDbContext : DbContext
{

    public DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=ProjexorDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

}