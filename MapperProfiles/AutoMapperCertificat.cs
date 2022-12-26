using AutoMapper;
using portfolio.DTOs.Certificat;
using portfolio.models;

namespace portfolio.mapperprofiles
{
    public class AutoMapperCertificat : Profile
    {
        public AutoMapperCertificat()
        {
            CreateMap<Certificat,GetCertificatDto>();
            CreateMap<AddCertificatDto,Certificat>();
        }

    }
}