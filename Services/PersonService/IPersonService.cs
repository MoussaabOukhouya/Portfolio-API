using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portfolio.DTOs.PersonDTO;
using portfolio.models;

namespace portfolio.Services.PersonService
{
    public interface IPersonService
    {
        Task<ServiceResponse<List<GetPersonDto>>> GetAllPersons();
        Task<ServiceResponse<GetPersonDto>> GetPersonById(int Id);
        Task<ServiceResponse<List<GetPersonDto>>> AddPerson(AddPersonDto addPersonDto);
        Task<ServiceResponse<GetPersonDto>> UpdatePerson(UpdatePersonDto updateExperienceDto);
        Task<ServiceResponse<List<GetPersonDto>>> DeletePerson(int Id);
    }
}