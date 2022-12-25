using Microsoft.AspNetCore.Mvc;
using portfolio.dal;
using portfolio.Services.CertificatService;
using System.Linq;


namespace portfolio.Controllers;

[ApiController]
[Route("[controller]")]
public class CertificatController : ControllerBase
{

    private readonly ICertificatService certificatService;

    public CertificatController(ICertificatService certificatService)
    {
        this.certificatService = certificatService;
    }

    [HttpGet("GetAll")]
    public IActionResult GetALL()
    {
  
        var certificat  = this.certificatService.GetAllCertificats();
        return Ok(certificat);
   
    }

    [HttpGet("{Id}")]
    public IActionResult GetCertificatById(int Id)
    {
  
        var certificat  = this.certificatService.GetCertificatById(Id);
        return Ok(certificat);
   
    }

    [HttpPost("AddCertificat")]
    public IActionResult AddCertificat()
    {
  
        return Ok();
   
    }
}
