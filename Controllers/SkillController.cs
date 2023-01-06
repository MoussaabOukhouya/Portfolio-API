using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using portfolio.DTOs.SkillDTO;
using portfolio.Shared;
using portfolio.Services.SkillService;

namespace portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> GetALL()
        {

            var skill = _skillService.GetAllSkills();
            return Ok(await skill);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> GetSkillById(int Id)
        {

            var skill = _skillService.GetSkillById(Id);
            return Ok(await skill);

        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> AddSkill(AddSkillDto addSkillDto)
        {

            return Ok(await _skillService.AddSkill(addSkillDto));

        }

        [HttpPut()]

        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> UpdateSkill(UpdateSkillDto updateSkillDto)
        {
            var serviceResponse = await _skillService.UpdateSkill(updateSkillDto);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _skillService.GetAllSkills());

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> DeleteSkill(int Id)
        {
            var serviceResponse = await _skillService.DeleteSkill(Id);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _skillService.GetAllSkills());
        }
    }
}