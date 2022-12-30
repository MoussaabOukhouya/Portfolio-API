using portfolio.models;

namespace portfolio.DTOs.Experience
{
    public class UpdateExperienceDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string companyImage { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public ICollection<Project> projects { get; set; }
    }
}