using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.DTOs.SocialMediaDTO;
using portfolio.models;

namespace portfolio.Services.SocialMediaService
{
    public interface ISocialMediaService 
    {
        Task<ServiceResponse<List<GetSocialMediaDto>>> GetAll();
        Task<ServiceResponse<GetSocialMediaDto>> GetSocialMediaById(int Id);
        Task<ServiceResponse<List<GetSocialMediaDto>>> AddSocialMedia(AddSocialMediaDto addSocialMediaDto);
        Task<ServiceResponse<GetSocialMediaDto>> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto);
        Task<ServiceResponse<List<GetSocialMediaDto>>> DeleteSocialMedia(int Id);
    }
}