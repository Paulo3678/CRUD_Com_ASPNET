using Domain.Model.User;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data;

public class DomainAppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DomainAppDbContext(DbContextOptions<DomainAppDbContext> options) :
        base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
