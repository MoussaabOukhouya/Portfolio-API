

using portfolio.models
;

namespace portfolio.Services.CertificatService
{
    public interface ICertificatService {

        Task<ServiceResponse<List<Certificat>>> GetAllCertificats();
        Task<ServiceResponse<Certificat>> GetCertificatById(int Id);
        Task<ServiceResponse<List<Certificat>>> AddCertificat(Certificat certificat);

        
    }
}