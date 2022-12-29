
using Microsoft.EntityFrameworkCore;
using portfolio.models;

namespace portfolio.data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Certificat> certificats => Set<Certificat>();
        
    }

   
}