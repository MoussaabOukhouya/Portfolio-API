using portfolio.models;

namespace portfolio.DTOs.ExperienceDTO
{
    public class AddExperienceDto
    {
        
        public string name { get; set; }
        public string description { get; set; }
        public string companyImage { get; set; }
        public DateTime startDate {get;set;}
        public DateTime endDate {get;set;}
        public ICollection<Project> projects { get; set; }
    }
}