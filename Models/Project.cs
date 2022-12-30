
namespace portfolio.models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string methodologie { get; set; }
        public string role { get; set; }
        public string githubLink { get; set; }
        public ICollection<Skill> skills { get; set; }


    }
}