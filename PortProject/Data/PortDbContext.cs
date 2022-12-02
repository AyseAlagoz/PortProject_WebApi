using Microsoft.EntityFrameworkCore;
using PortProject.Models;

namespace PortProject.Data
{
    public class PortDbContext : DbContext 
    {
        public PortDbContext(DbContextOptions options) : base(options)
        {
         
        }
        public DbSet<PortModel> portModels { get; set; } 

    }
}
