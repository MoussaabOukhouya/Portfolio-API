using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using portfolio.DTOs.ToolDTO;
using portfolio.models;
using portfolio.Services.ToolService;

namespace portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly IToolService _toolService;

        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetToolDto>>>> GetALL()
        {

            var tools = _toolService.GetAllTools();
            return Ok(await tools);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetToolDto>>> GetToolById(int Id)
        {

            var tool = _toolService.GetToolById(Id);
            return Ok(await tool);

        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<GetToolDto>>>> AddTool(AddToolDto addToolDto)
        {

            return Ok(await _toolService.AddTool(addToolDto));

        }

        [HttpPut()]

        public async Task<ActionResult<ServiceResponse<List<GetToolDto>>>> UpdateTool(UpdateToolDto updateToolDto)
        {
            var serviceResponse = await _toolService.UpdateTool(updateToolDto);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _toolService.GetAllTools());

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<ServiceResponse<List<GetToolDto>>>> DeleteTool(int Id)
        {
            var serviceResponse = await _toolService.DeleteTool(Id);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _toolService.GetAllTools());
        }
    }
}