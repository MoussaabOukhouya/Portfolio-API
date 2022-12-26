using Microsoft.AspNetCore.Mvc;
using portfolio.dal;
using portfolio.DTOs.Certificat;
using portfolio.models;
using portfolio.Services.CertificatService;
using System.Linq;


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
  
        var certificat  = _certificatService.GetAllCertificats();
        return Ok(await certificat);
   
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ServiceResponse<GetCertificatDto>>> GetCertificatById(int Id)
    {
  
        var certificat  = _certificatService.GetCertificatById(Id);
        return Ok(await certificat);
   
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<GetCertificatDto>>>> AddCertificat(AddCertificatDto addCertificatDto)
    {
  
        return Ok(await _certificatService.AddCertificat(addCertificatDto));
   
    }
}
