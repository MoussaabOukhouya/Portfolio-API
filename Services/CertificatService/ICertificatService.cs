

using portfolio.DTOs.Certificat;
using portfolio.models;


namespace portfolio.Services.CertificatService
{
    public interface ICertificatService {

        Task<ServiceResponse<List<GetCertificatDto>>> GetAllCertificats();
        Task<ServiceResponse<GetCertificatDto>> GetCertificatById(int Id);
        Task<ServiceResponse<List<GetCertificatDto>>> AddCertificat(AddCertificatDto addCertificatDto);
        Task<ServiceResponse<GetCertificatDto>> UpdateCertificat(UpdateCertificatDto updateCertificatDto);


        
    }
}