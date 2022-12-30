using AutoMapper;
using portfolio.data;
using portfolio.DTOs.ProjectDTO;
using portfolio.models;
using Microsoft.EntityFrameworkCore;

namespace portfolio.Services.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _dbContext;

        public ProjectService(IMapper mapper, MyDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> AddProject(AddProjectDto addProjectDto)
        {
            var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            var dbProjects = await _dbContext.projects.ToListAsync();
            await _dbContext.AddAsync(_mapper.Map<Project>(addProjectDto));
            await _dbContext.SaveChangesAsync();
            serviceResponse.data = dbProjects.Select(c => _mapper.Map<GetProjectDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> DeleteProject(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            var dbProjects = await _dbContext.projects.ToListAsync();
            try
            {
                var project = await _dbContext.projects.FindAsync(Id);
                if (project is null)
                    throw new Exception($"The Project with the Id: '{Id}' is not found.");

                _dbContext.projects.Remove(project);
                serviceResponse.data = dbProjects.Select(c => _mapper.Map<GetProjectDto>(c)).ToList();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAllProjects()
        {
            var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            serviceResponse.data = await _dbContext.projects.Select(c => _mapper.Map<GetProjectDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> GetProjectById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetProjectDto>();
            var dbProject = await _dbContext.projects.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetProjectDto>(dbProject);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto updateProjectDto)
        {
            var serviceResponse = new ServiceResponse<GetProjectDto>();
            try
            {
                var project = await _dbContext.projects.FindAsync(updateProjectDto.Id);
                if (project is null)
                    throw new Exception($"The Project with the Id: '{updateProjectDto.Id}' is not found.");

                project.Name = updateProjectDto.Name;
                project.startDate = updateProjectDto.startDate;
                project.endDate = updateProjectDto.endDate;
                project.Description = updateProjectDto.Description;
                project.githubLink = updateProjectDto.githubLink;
                project.methodologie = updateProjectDto.methodologie;
                project.role = updateProjectDto.role;
                project.skills = updateProjectDto.skills;
                
                await _dbContext.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetProjectDto>(project);
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        Task<ServiceResponse<List<AddProjectDto>>> IProjectService.AddProject(AddProjectDto addProjectDto)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<AddProjectDto>>> IProjectService.DeleteProject(int Id)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<AddProjectDto>>> IProjectService.GetAllProjects()
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<AddProjectDto>> IProjectService.GetProjectById(int Id)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<AddProjectDto>> IProjectService.UpdateProject(UpdateProjectDto updateProjectDto)
        {
            throw new NotImplementedException();
        }
    }
}