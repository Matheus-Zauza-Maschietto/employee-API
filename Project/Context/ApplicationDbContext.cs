using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Context;

public class ApplicationDbContext: DbContext
{
    public DbSet<Endereco> Endereco { get; set; }
    public DbSet<Pessoa> Pessoa { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

}
