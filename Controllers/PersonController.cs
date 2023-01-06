using Microsoft.AspNetCore.Mvc;
using portfolio.DTOs.PersonDTO;
using portfolio.Shared;
using portfolio.Services.PersonService;

namespace portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> GetALL()
        {

            var person = _personService.GetAllPersons();
            return Ok(await person);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ServiceResponse<GetPersonDto>>> GetPersonById(int Id)
        {

            var person = _personService.GetPersonById(Id);
            return Ok(await person);

        }

        [HttpPost()]
        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> AddPerson(AddPersonDto addPersonDto)
        {

            return Ok(await _personService.AddPerson(addPersonDto));

        }

        [HttpPut()]

        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> UpdatePerson(UpdatePersonDto updatePersonDto)
        {
            var serviceResponse = await _personService.UpdatePerson(updatePersonDto);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _personService.GetAllPersons());

        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<ServiceResponse<List<GetPersonDto>>>> DeletePerson(int Id)
        {
            var serviceResponse = await _personService.DeletePerson(Id);
            if (serviceResponse.data is null)
                return NotFound(serviceResponse);

            return Ok(await _personService.GetAllPersons());
        }

    }
}