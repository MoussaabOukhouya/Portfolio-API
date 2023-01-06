using Microsoft.EntityFrameworkCore;
using AutoMapper;
using portfolio.data;
using portfolio.DTOs.SkillDTO;
using portfolio.models;
using portfolio.Shared;


namespace portfolio.Services.SkillService
{
    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _dbContext;

        public SkillService(IMapper mapper, MyDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> AddSkill(AddSkillDto addSkillDto)
        {
            var serviceResponse = new ServiceResponse<List<GetSkillDto>>();
            var dbSkills = await _dbContext.skills.ToListAsync();
            await _dbContext.AddAsync(_mapper.Map<Skill>(addSkillDto));
            await _dbContext.SaveChangesAsync();
            serviceResponse.data = dbSkills.Select(c => _mapper.Map<GetSkillDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> DeleteSkill(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetSkillDto>>();
            var dbSkills = await _dbContext.skills.ToListAsync();
            try
            {
                var skill = await _dbContext.skills.FindAsync(Id);
                if (skill is null)
                    throw new Exception($"The Skill with the Id: '{Id}' is not found.");

                _dbContext.skills.Remove(skill);
                serviceResponse.data = dbSkills.Select(c => _mapper.Map<GetSkillDto>(c)).ToList();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> GetAllSkills()
        {
            var serviceResponse = new ServiceResponse<List<GetSkillDto>>();
            serviceResponse.data = await _dbContext.skills.Select(c => _mapper.Map<GetSkillDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSkillDto>> GetSkillById(int Id)
        {
             var serviceResponse = new ServiceResponse<GetSkillDto>();
            var dbSkills = await _dbContext.skills.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetSkillDto>(dbSkills);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSkillDto>> UpdateSkill(UpdateSkillDto updateSkillDto)
        {
            var serviceResponse = new ServiceResponse<GetSkillDto>();
            try
            {
                var skill = await _dbContext.skills.FindAsync(updateSkillDto.Id);
                if (skill is null)
                    throw new Exception($"The certificat with the Id: '{updateSkillDto.Id}' is not found.");

                skill.name = updateSkillDto.name;
                skill.description = updateSkillDto.description;
                skill.certificat = updateSkillDto.certificat;
                skill.image = updateSkillDto.image;
                skill.level = updateSkillDto.level;

                await _dbContext.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetSkillDto>(skill);
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }
    }
}