using AutoMapper;
using Microsoft.EntityFrameworkCore;
using portfolio.data;
using portfolio.DTOs.ToolDTO;
using portfolio.models;
using portfolio.Shared;

namespace portfolio.Services.ToolService
{
    public class ToolService : IToolService
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _dbContext;

        public ToolService(IMapper mapper, MyDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<GetToolDto>>> AddTool(AddToolDto addToolDto)
        {
            var serviceResponse = new ServiceResponse<List<GetToolDto>>();
            var dbTools = await _dbContext.tools.ToListAsync();
            await _dbContext.AddAsync(_mapper.Map<Tool>(addToolDto));
            await _dbContext.SaveChangesAsync();
            serviceResponse.data = dbTools.Select(c => _mapper.Map<GetToolDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetToolDto>>> DeleteTool(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetToolDto>>();
            var dbTools = await _dbContext.tools.ToListAsync();
            try
            {
                var tool = await _dbContext.tools.FindAsync(Id);
                if (tool is null)
                    throw new Exception($"The certifcat with the Id: '{Id}' is not found.");

                _dbContext.tools.Remove(tool);
                serviceResponse.data = dbTools.Select(c => _mapper.Map<GetToolDto>(c)).ToList();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetToolDto>>> GetAllTools()
        {
            var serviceResponse = new ServiceResponse<List<GetToolDto>>();
            serviceResponse.data = await _dbContext.tools.Select(c => _mapper.Map<GetToolDto>(c)).ToListAsync();
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetToolDto>> GetToolById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetToolDto>();
            var dbTools = await _dbContext.tools.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetToolDto>(dbTools);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetToolDto>> UpdateTool(UpdateToolDto updateToolDto)
        {
            var serviceResponse = new ServiceResponse<GetToolDto>();
            try
            {
                var tool = await _dbContext.tools.FindAsync(updateToolDto.Id);
                if (tool is null)
                    throw new Exception($"The certificat with the Id: '{updateToolDto.Id}' is not found.");

                tool.name = updateToolDto.name;
                tool.description = updateToolDto.description;
                tool.image = updateToolDto.image;
                tool.link = updateToolDto.link;

                await _dbContext.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetToolDto>(tool);
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