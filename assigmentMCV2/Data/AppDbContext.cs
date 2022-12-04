using assigmentMVC2.Models;
using Microsoft.EntityFrameworkCore;

namespace assigmentMVC2.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Person>? People { get; set; }
    public DbSet<Country>? Countries { get; set; }
    public DbSet<City>? Cities { get; set; }

}