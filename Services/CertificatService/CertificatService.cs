
using portfolio.models
;

namespace portfolio.Services.CertificatService
{
    public class CertificatService : ICertificatService
    {
        private static List<Certificat> certificats = new List<Certificat>{
            new Certificat{Id = 1 , name="test", description="test",image="test",link="test"},
            new Certificat{Id = 2 , name="momo", description="dodo",image="mimi",link="khoko"}};

        public async Task<ServiceResponse<List<Certificat>>> AddCertificat(Certificat certificat)
        {
            var serviceResponse = new ServiceResponse<List<Certificat>>();
            certificats.Add(certificat);
            serviceResponse.data = certificats;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Certificat>>> GetAllCertificats()
        {
            var serviceResponse = new ServiceResponse<List<Certificat>>();
            serviceResponse.data = certificats;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Certificat>> GetCertificatById(int Id)
        {
            var serviceResponse = new ServiceResponse<Certificat>();
            serviceResponse.data = certificats.FirstOrDefault(c => c.Id == Id);
            return serviceResponse;
        }
    }
}