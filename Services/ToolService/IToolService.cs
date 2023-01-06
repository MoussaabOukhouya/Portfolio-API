using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.DTOs.ToolDTO;
using portfolio.Shared;

namespace portfolio.Services.ToolService
{
    public interface IToolService 
    {
        Task<ServiceResponse<List<GetToolDto>>> GetAllTools();
        Task<ServiceResponse<GetToolDto>> GetToolById(int Id);
        Task<ServiceResponse<List<GetToolDto>>> AddTool(AddToolDto addToolDto);
        Task<ServiceResponse<GetToolDto>> UpdateTool(UpdateToolDto updateToolDto);
        Task<ServiceResponse<List<GetToolDto>>> DeleteTool(int Id);
    }
}