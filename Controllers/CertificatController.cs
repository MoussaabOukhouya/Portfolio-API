using Microsoft.AspNetCore.Mvc;
using portfolio.DTOs.CertificatDTO;
using portfolio.Services.CertificatService;
using portfolio.Shared;

namespace portfolio.Controllers;

[ApiController]
[Route("[controller]")]
public class CertificatController : ControllerBase
{

    private readonly ICertificatService _certificatService;

    public CertificatController(ICertificatService certificatService)
    {
        _certificatService = certificatService;
    }


    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCertificatDto>>>> GetALL()
    {

        var certificat = _certificatService.GetAllCertificats();
        return Ok(await certificat);

    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ServiceResponse<GetCertificatDto>>> GetCertificatById(int Id)
    {

        var certificat = _certificatService.GetCertificatById(Id);
        return Ok(await certificat);

    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<GetCertificatDto>>>> AddCertificat(AddCertificatDto addCertificatDto)
    {

        return Ok(await _certificatService.AddCertificat(addCertificatDto));

    }

    [HttpPut()]

    public async Task<ActionResult<ServiceResponse<List<GetCertificatDto>>>> UpdateCertificat(UpdateCertificatDto updateCertificatDto)
    {
        var serviceResponse = await _certificatService.UpdateCertificat(updateCertificatDto);
        if (serviceResponse.data is null)
            return NotFound(serviceResponse);

        return Ok(await _certificatService.GetAllCertificats());

    }

    [HttpDelete("{Id}")]

    public async Task<ActionResult<ServiceResponse<List<GetCertificatDto>>>> DeleteCertificat(int Id)
    {
        var serviceResponse = await _certificatService.DeleteCertificat(Id);
        if (serviceResponse.data is null)
            return NotFound(serviceResponse);

        return Ok(await _certificatService.GetAllCertificats());
    }
}
