using assigmentMVC2.Models;
using Microsoft.EntityFrameworkCore;

namespace assigmentMVC2.Data;
public class PeopleDbContext : DbContext
{
    public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
    { }
    public DbSet<Person>? People { get; set; }
}