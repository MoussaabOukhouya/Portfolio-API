using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.DTOs.SkillDTO;
using portfolio.Shared;

namespace portfolio.Services.SkillService
{
    public interface ISkillService
    {
        Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills();
        Task<ServiceResponse<GetSkillDto>> GetSkillById(int Id);
        Task<ServiceResponse<List<GetSkillDto>>> AddSkill(AddSkillDto addSkillDto);
        Task<ServiceResponse<GetSkillDto>> UpdateSkill(UpdateSkillDto updateSkillDto);
        Task<ServiceResponse<List<GetSkillDto>>> DeleteSkill(int Id);
    }
}