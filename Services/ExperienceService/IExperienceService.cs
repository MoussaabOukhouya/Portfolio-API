using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.DTOs.ExperienceDTO;
using portfolio.models;

namespace portfolio.Services.ExperienceService
{
    public interface IExperienceService
    {
        Task<ServiceResponse<List<GetExperienceDto>>> GetAllExperiences();
        Task<ServiceResponse<GetExperienceDto>> GetExperienceById(int Id);
        Task<ServiceResponse<List<GetExperienceDto>>> AddExperience(AddExperienceDto addExperienceDto);
        Task<ServiceResponse<GetExperienceDto>> UpdateExperience(UpdateExperienceDto updateExperienceDto);
        Task<ServiceResponse<List<GetExperienceDto>>> DeleteExperience(int Id);
    }
}