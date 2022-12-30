

using portfolio.DTOs.CertificatDTO;
using portfolio.models;


namespace portfolio.Services.CertificatService
{
    public interface ICertificatService {

        Task<ServiceResponse<List<GetCertificatDto>>> GetAllCertificats();
        Task<ServiceResponse<GetCertificatDto>> GetCertificatById(int Id);
        Task<ServiceResponse<List<GetCertificatDto>>> AddCertificat(AddCertificatDto addCertificatDto);
        Task<ServiceResponse<GetCertificatDto>> UpdateCertificat(UpdateCertificatDto updateCertificatDto);
        Task<ServiceResponse<List<GetCertificatDto>>> DeleteCertificat(int Id);



        
    }
}