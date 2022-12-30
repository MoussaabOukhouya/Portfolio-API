using Microsoft.AspNetCore.Mvc;
using portfolio.DTOs.ProjectDTO;
using portfolio.models;
using portfolio.Services.ProjectService;

namespace portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> GetALL()
        {

            var project = _projectService.GetAllProjects();
            return Ok(await project);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetProjectDto>>> GetProjectById(int Id)
        {

            var project = _projectService.GetProjectById(Id);
            return Ok(await project);

        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> AddProject(AddProjectDto addProjectDto)
        {

            return Ok(await _projectService.AddProject(addProjectDto));

        }

        [HttpPut()]

        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> UpdatePerson(UpdateProjectDto updateProjectDto)
        {
            var serviceResponse = await _projectService.UpdateProject(updateProjectDto);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _projectService.GetAllProjects());

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> DeletePerson(int Id)
        {
            var serviceResponse = await _projectService.DeleteProject(Id);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _projectService.GetAllProjects());
        }
    }
}