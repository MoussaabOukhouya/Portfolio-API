
using portfolio.models
;

namespace portfolio.Services.CertificatService
{
    public class CertificatService : ICertificatService
    {
        private static List<Certificat> certificats = new List<Certificat>{
            new Certificat{Id = 1 , name="test", description="test",image="test",link="test"},
            new Certificat{Id = 2 , name="momo", description="dodo",image="mimi",link="khoko"}};

        public List<Certificat> AddCertificat(Certificat certificat)
        {
            certificats.Add(certificat);
            return certificats;
        }

        public List<Certificat> GetAllCertificats()
        {
            return certificats;
        }

        public Certificat GetCertificatById(int Id)
        {
            return certificats.FirstOrDefault(c => c.Id == Id) ;
        }
    }
}