using Microsoft.EntityFrameworkCore;
using AutoMapper;
using portfolio.data;
using portfolio.DTOs.SocialMediaDTO;
using portfolio.models;
using portfolio.Shared;

namespace portfolio.Services.SocialMediaService
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _dbContext;

        public SocialMediaService(IMapper mapper, MyDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<GetSocialMediaDto>>> AddSocialMedia(AddSocialMediaDto addSocialMediaDto)
        {
            var serviceResponse = new ServiceResponse<List<GetSocialMediaDto>>();
            var dbsocialMedias = await _dbContext.socialMedias.ToListAsync();
            await _dbContext.AddAsync(_mapper.Map<SocialMedia>(addSocialMediaDto));
            await _dbContext.SaveChangesAsync();
            serviceResponse.data = dbsocialMedias.Select(c => _mapper.Map<GetSocialMediaDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSocialMediaDto>>> DeleteSocialMedia(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetSocialMediaDto>>();
            var dbsocialMedias = await _dbContext.socialMedias.ToListAsync();
            try
            {
                var socialMedia = await _dbContext.socialMedias.FindAsync(Id);
                if (socialMedia is null)
                    throw new Exception($"The Social Media with the Id: '{Id}' is not found.");

                _dbContext.socialMedias.Remove(socialMedia);
                serviceResponse.data = dbsocialMedias.Select(c => _mapper.Map<GetSocialMediaDto>(c)).ToList();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSocialMediaDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetSocialMediaDto>>();
            serviceResponse.data = await _dbContext.socialMedias.Select(c => _mapper.Map<GetSocialMediaDto>(c)).ToListAsync();
            return serviceResponse;
        }

      

        public async Task<ServiceResponse<GetSocialMediaDto>> GetSocialMediaById(int Id)
        {
             var serviceResponse = new ServiceResponse<GetSocialMediaDto>();
            var dbsocialMedias = await _dbContext.socialMedias.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetSocialMediaDto>(dbsocialMedias);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSocialMediaDto>> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var serviceResponse = new ServiceResponse<GetSocialMediaDto>();
            try
            {
                var socialMedia = await _dbContext.socialMedias.FindAsync(updateSocialMediaDto.Id);
                if (socialMedia is null)
                    throw new Exception($"The certificat with the Id: '{updateSocialMediaDto.Id}' is not found.");

                socialMedia.name = updateSocialMediaDto.name;
                socialMedia.image = updateSocialMediaDto.image;
                socialMedia.link = updateSocialMediaDto.link;
                

                await _dbContext.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetSocialMediaDto>(socialMedia);
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