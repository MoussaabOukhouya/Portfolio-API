
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
        public DbSet<Experience> experiences => Set<Experience>();
        public DbSet<Person> persons => Set<Person>();
        public DbSet<Project> projects => Set<Project>();
        public DbSet<Skill> skills => Set<Skill>();
        public DbSet<SocialMedia> socialMedias => Set<SocialMedia>();
        public DbSet<Tool> tools => Set<Tool>();

        
    }

   
}