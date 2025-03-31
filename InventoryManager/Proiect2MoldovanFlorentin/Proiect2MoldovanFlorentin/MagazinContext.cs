using Proiect2MoldovanFlorentin;
using System.Data.Entity;

public class MagazinContext : DbContext
{
    public DbSet<Produs> Produs { get; set; }
    public DbSet<Vanzare> Vanzare { get; set; }
    public DbSet<User> User { get; set; }

    public MagazinContext() : base("magazindbcontext")
    {  
    }
}