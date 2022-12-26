
using AutoMapper;
using portfolio.DTOs.Certificat;
using portfolio.models
;

namespace portfolio.Services.CertificatService
{
    public class CertificatService : ICertificatService
    {
        IMapper _mapper;
        private static List<Certificat> certificats = new List<Certificat>{
            new Certificat{Id = 1 , name="test", description="test",image="test",link="test"},
            new Certificat{Id = 2 , name="momo", description="dodo",image="mimi",link="khoko"}};

        public CertificatService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCertificatDto>>> AddCertificat(AddCertificatDto addCertificatDto)
        {
            var serviceResponse = new ServiceResponse<List<GetCertificatDto>>();
            certificats.Add(_mapper.Map<Certificat>(addCertificatDto));
            serviceResponse.data = certificats.Select(c => _mapper.Map<GetCertificatDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCertificatDto>>> GetAllCertificats()
        {
            var serviceResponse = new ServiceResponse<List<GetCertificatDto>>();
            serviceResponse.data =certificats.Select(c => _mapper.Map<GetCertificatDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCertificatDto>> GetCertificatById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCertificatDto>();
            var certificat = certificats.FirstOrDefault(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetCertificatDto>(certificat);
            return serviceResponse;
        }
    }
}