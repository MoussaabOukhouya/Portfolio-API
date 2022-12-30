
namespace portfolio.models
{
    public class Experience
    {
        public int Id { get; set; }
        public string name { get; set; } = "Développeur .Net";
        public string description { get; set; } = "";
        public string companyImage { get; set; } = "Capgemini";
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public ICollection<Project> projects { get; set; }


    }
}