using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using portfolio.data;
using Microsoft.EntityFrameworkCore;
using portfolio.DTOs.PersonDTO;
using portfolio.models;
using portfolio.Shared;

namespace portfolio.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;

        private readonly MyDbContext _dbContext;

        public PersonService(IMapper mapper, MyDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDto addPersonDto)
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            var dbPersons = await _dbContext.persons.ToListAsync();
            await _dbContext.AddAsync(_mapper.Map<Person>(addPersonDto));
            await _dbContext.SaveChangesAsync();
            serviceResponse.data = dbPersons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int Id)
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            var dbPersons = await _dbContext.persons.ToListAsync();
            try
            {
                var person = await _dbContext.persons.FindAsync(Id);
                if (person is null)
                    throw new Exception($"The certifcat with the Id: '{Id}' is not found.");

                _dbContext.persons.Remove(person);
                serviceResponse.data = dbPersons.Select(c => _mapper.Map<GetPersonDto>(c)).ToList();
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons()
        {
            var serviceResponse = new ServiceResponse<List<GetPersonDto>>();
            serviceResponse.data = await _dbContext.persons.Select(c => _mapper.Map<GetPersonDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> GetPersonById(int Id)
        {
             var serviceResponse = new ServiceResponse<GetPersonDto>();
            var dbPersons = await _dbContext.persons.FirstOrDefaultAsync(c => c.Id == Id);
            serviceResponse.data = _mapper.Map<GetPersonDto>(dbPersons);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPersonDto>> UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            var serviceResponse = new ServiceResponse<GetPersonDto>();
            try
            {
                var person = await _dbContext.persons.FindAsync(updatePersonDto.Id);
                if (person is null)
                    throw new Exception($"The Person with the Id: '{updatePersonDto.Id}' is not found.");

                person.firstName = updatePersonDto.firstName;
                person.lastName = updatePersonDto.lastName;
                person.image = updatePersonDto.image;
                person.biographie = updatePersonDto.biographie;
                person.profession = updatePersonDto.profession;
                person.resume = updatePersonDto.resume;
                person.experiences = updatePersonDto.experiences;
                person.skills = updatePersonDto.skills;
                person.tools = updatePersonDto.tools;
                person.socialMedias = updatePersonDto.socialMedias;

                await _dbContext.SaveChangesAsync();
                serviceResponse.data = _mapper.Map<GetPersonDto>(person);
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