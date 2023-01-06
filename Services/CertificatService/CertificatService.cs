
using AutoMapper;
using portfolio.data;
using portfolio.DTOs.CertificatDTO;
using portfolio.models;
using Microsoft.EntityFrameworkCore;
using portfolio.Shared;



namespace portfolio.Services.CertificatService
{
    public class CertificatService : ICertificatService
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _dbContext;

        public CertificatService(IMapper mapper, MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCertificatDto>>> AddCertificat(AddCertificatDto addCertificatDto)
        {
            var serviceResponse = new ServiceResponse<List<GetCertificatDto>>();
            var dbCertificats = await _dbContext.certificats.ToListAsync();
            await _dbContext.AddAsync(_mapper.Map<Certificat>(addCertificatDto));
            await _dbContext.SaveChangesAsync();
            serviceResponse.data = dbCertificats.Select(c => _mapper.Map<GetCertificatDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCertificatDto>>> GetAllCertificats()
        {
            var serviceResponse = new ServiceResponse<List<GetCertificatDto>>();
            serviceResponse.data = await _dbContext.certificats.Select(c => _mapper.Map<GetCertificatDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCertificatDto>> GetCertificatById(int Id)
        {
            var serviceResponse = new ServiceResponse<GetCertificatDto>();
            var dbCertificats = await _dbContext.certificats.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetCertificatDto>(dbCertificats);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCertificatDto>> UpdateCertificat(UpdateCertificatDto updateCertificatDto)
        {
            var serviceResponse = new ServiceResponse<GetCertificatDto>();
            try
            {
                var certificat = await _dbContext.certificats.FindAsync(updateCertificatDto.Id);
                if (certificat is null)
                    throw new Exception($"The certificat with the Id: '{updateCertificatDto.Id}' is not found.");

                certificat.name = updateCertificatDto.name;
                certificat.description = updateCertificatDto.description;
                certificat.image = updateCertificatDto.image;
                certificat.link = updateCertificatDto.link;

                await _dbContext.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetCertificatDto>(certificat);
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCertificatDto>>> DeleteCertificat(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetCertificatDto>>();
            var dbCertificats = await _dbContext.certificats.ToListAsync();
            try
            {
                var certificat = await _dbContext.certificats.FindAsync(Id);
                if (certificat is null)
                    throw new Exception($"The certifcat with the Id: '{Id}' is not found.");

                _dbContext.certificats.Remove(certificat);
                serviceResponse.data = dbCertificats.Select(c => _mapper.Map<GetCertificatDto>(c)).ToList();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }
    }
}