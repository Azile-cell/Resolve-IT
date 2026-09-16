using Microsoft.EntityFrameworkCore;
using ResolveIT.Web.Models;

namespace ResolveIT.Web.Data;

public class ResolveITDbContext : DbContext
{
    public ResolveITDbContext(
        DbContextOptions<ResolveITDbContext> options)
        : base(options)
    {
    
    }
        public DbSet<Ticket> Tickets => Set<Ticket>();

    
}