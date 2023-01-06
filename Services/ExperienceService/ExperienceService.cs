using Microsoft.EntityFrameworkCore;
using AutoMapper;
using portfolio.data;
using portfolio.DTOs.ExperienceDTO;
using portfolio.models;
using portfolio.Shared;

namespace portfolio.Services.ExperienceService
{
    public class ExperienceService : IExperienceService
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _dbContext;

        public ExperienceService(IMapper mapper, MyDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<GetExperienceDto>>> AddExperience(AddExperienceDto addExperienceDto)
        {
            var serviceResponse = new ServiceResponse<List<GetExperienceDto>>();
            var dbExperiences = await _dbContext.experiences.ToListAsync();
            await _dbContext.AddAsync(_mapper.Map<Experience>(addExperienceDto));
            await _dbContext.SaveChangesAsync();
            serviceResponse.data = dbExperiences.Select(c => _mapper.Map<GetExperienceDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetExperienceDto>>> DeleteExperience(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetExperienceDto>>();
            var dbExperiences = await _dbContext.experiences.ToListAsync();
            try
            {
                var experience = await _dbContext.experiences.FindAsync(Id);
                if (experience is null)
                    throw new Exception($"The certifcat with the Id: '{Id}' is not found.");

                _dbContext.experiences.Remove(experience);
                serviceResponse.data = dbExperiences.Select(c => _mapper.Map<GetExperienceDto>(c)).ToList();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetExperienceDto>>> GetAllExperiences()
        {
            var serviceResponse = new ServiceResponse<List<GetExperienceDto>>();
            serviceResponse.data = await _dbContext.experiences.Select(c => _mapper.Map<GetExperienceDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetExperienceDto>> GetExperienceById(int Id)
        {
             var serviceResponse = new ServiceResponse<GetExperienceDto>();
            var dbExperiences = await _dbContext.experiences.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetExperienceDto>(dbExperiences);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetExperienceDto>> UpdateExperience(UpdateExperienceDto updateExperienceDto)
        {
            var serviceResponse = new ServiceResponse<GetExperienceDto>();
            try
            {
                var experience = await _dbContext.experiences.FindAsync(updateExperienceDto.Id);
                if (experience is null)
                    throw new Exception($"The certificat with the Id: '{updateExperienceDto.Id}' is not found.");

                experience.name = updateExperienceDto.name;
                experience.description = updateExperienceDto.description;
                experience.companyImage = updateExperienceDto.companyImage;
                experience.startDate = updateExperienceDto.startDate;
                experience.endDate = updateExperienceDto.endDate;
                experience.projects = updateExperienceDto.projects;

                await _dbContext.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetExperienceDto>(experience);
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