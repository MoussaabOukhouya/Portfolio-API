using Microsoft.AspNetCore.Mvc;
using portfolio.dal;
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
    public async Task<ActionResult<ServiceResponse<List<Certificat>>>> GetALL()
    {
  
        var certificat  = _certificatService.GetAllCertificats();
        return Ok(await certificat);
   
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ServiceResponse<Certificat>>> GetCertificatById(int Id)
    {
  
        var certificat  = _certificatService.GetCertificatById(Id);
        return Ok(await certificat);
   
    }

    [HttpPost()]
    public async Task<ActionResult<ServiceResponse<List<Certificat>>>> AddCertificat(Certificat certificat)
    {
  
        return Ok(await _certificatService.AddCertificat(certificat));
   
    }
}
