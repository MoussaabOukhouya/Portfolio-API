using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using portfolio.DTOs.SocialMediaDTO;
using portfolio.Shared;
using portfolio.Services.SocialMediaService;

namespace portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSocialMediaDto>>>> GetALL()
        {

            var socialMedia = _socialMediaService.GetAll();
            return Ok(await socialMedia);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetSocialMediaDto>>> GetSkillById(int Id)
        {

            var socialMedia = _socialMediaService.GetSocialMediaById(Id);
            return Ok(await socialMedia);

        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<GetSocialMediaDto>>>> AddSocialMedia(AddSocialMediaDto addSocialMediaDto)
        {

            return Ok(await _socialMediaService.AddSocialMedia(addSocialMediaDto));

        }

        [HttpPut()]

        public async Task<ActionResult<ServiceResponse<List<GetSocialMediaDto>>>> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var serviceResponse = await _socialMediaService.UpdateSocialMedia(updateSocialMediaDto);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _socialMediaService.GetAll());

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<ServiceResponse<List<GetSocialMediaDto>>>> DeleteSocialMedia(int Id)
        {
            var serviceResponse = await _socialMediaService.DeleteSocialMedia(Id);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _socialMediaService.GetAll());
        }
    }
}