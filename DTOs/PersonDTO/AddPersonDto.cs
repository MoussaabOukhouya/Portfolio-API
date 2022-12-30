using portfolio.models;

namespace portfolio.DTOs.PersonDTO
{
    public class AddPersonDto
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string image { get; set; }
        public string biographie { get; set; }
        public string profession { get; set; }
        public string resume { get; set; }
        public ICollection<Experience> experiences { get; set; }
        public ICollection<Skill> skills { get; set; }
        public ICollection<Tool> tools { get; set; }
        public ICollection<Certificat> certificats { get; set; }
        public ICollection<SocialMedia> socialMedias { get; set; }
    }
}