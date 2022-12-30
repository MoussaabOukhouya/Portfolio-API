using AutoMapper;
using portfolio.DTOs.CertificatDTO;
using portfolio.DTOs.ExperienceDTO;
using portfolio.DTOs.PersonDTO;
using portfolio.DTOs.ProjectDTO;
using portfolio.DTOs.SkillDTO;
using portfolio.DTOs.SocialMediaDTO;
using portfolio.DTOs.ToolDTO;
using portfolio.models;

namespace portfolio.mapperprofiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Certificat,GetCertificatDto>();
            CreateMap<AddCertificatDto,Certificat>();

            CreateMap<Experience,GetExperienceDto>();
            CreateMap<AddCertificatDto,Experience>();

            CreateMap<Person,GetPersonDto>();
            CreateMap<AddPersonDto,Person>();

            CreateMap<Project,GetProjectDto>();
            CreateMap<AddProjectDto,Project>();

            CreateMap<Skill,GetSkillDto>();
            CreateMap<AddSkillDto,Skill>();

            CreateMap<SocialMedia,GetSocialMediaDto>();
            CreateMap<AddSocialMediaDto,SocialMedia>();

            CreateMap<Tool,GetToolDto>();
            CreateMap<AddToolDto,Skill>();
        }

        

    }
}