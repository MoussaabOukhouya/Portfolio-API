using Microsoft.AspNetCore.Mvc;
using portfolio.DTOs.ExperienceDTO;
using portfolio.Shared;
using portfolio.Services.ExperienceService;

namespace portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetExperienceDto>>>> GetALL()
        {

            var certificat = _experienceService.GetAllExperiences();
            return Ok(await certificat);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetExperienceDto>>> GetExperienceById(int Id)
        {

            var certificat = _experienceService.GetExperienceById(Id);
            return Ok(await certificat);

        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<GetExperienceDto>>>> AddExperience(AddExperienceDto addExperienceDto)
        {

            return Ok(await _experienceService.AddExperience(addExperienceDto));

        }

        [HttpPut()]

        public async Task<ActionResult<ServiceResponse<List<GetExperienceDto>>>> UpdateExperience(UpdateExperienceDto updateExperienceDto)
        {
            var serviceResponse = await _experienceService.UpdateExperience(updateExperienceDto);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _experienceService.GetAllExperiences());

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<ServiceResponse<List<GetExperienceDto>>>> DeleteExperience(int Id)
        {
            var serviceResponse = await _experienceService.DeleteExperience(Id);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _experienceService.GetAllExperiences());
        }
    }
}