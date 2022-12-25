

using portfolio.models
;

namespace portfolio.Services.CertificatService
{
    public interface ICertificatService {

        List<Certificat> GetAllCertificats();
        Certificat GetCertificatById(int Id);
        List<Certificat> AddCertificat(Certificat certificat);

        
    }
}