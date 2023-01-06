using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.DTOs.ProjectDTO;
using portfolio.Shared;

namespace portfolio.Services.ProjectService
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<AddProjectDto>>> GetAllProjects();
        Task<ServiceResponse<AddProjectDto>> GetProjectById(int Id);
        Task<ServiceResponse<List<AddProjectDto>>> AddProject(AddProjectDto addProjectDto);
        Task<ServiceResponse<AddProjectDto>> UpdateProject(UpdateProjectDto updateProjectDto);
        Task<ServiceResponse<List<AddProjectDto>>> DeleteProject(int Id);
    }
}