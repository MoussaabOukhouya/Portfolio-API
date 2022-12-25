
using Microsoft.EntityFrameworkCore;
using portfolio.models
;

namespace portfolio.dal
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public Certificat certificats {get;set;}
        public Experience experience {get;set;}
        public Person person {get;set;}
        public Project project {get;set;}
        public Skill skill {get;set;}
        public SocialMedia socialMedia {get;set;}
        public Tool tool {get;set;}
    }

   
}