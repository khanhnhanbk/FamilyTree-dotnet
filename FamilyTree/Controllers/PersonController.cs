using FamilyTree.DTOs;
using FamilyTree.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll()
        {
            var people = await _personService.GetAllAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> Create(CreatePersonDto createPersonDto)
        {
            var createdPerson = await _personService.CreateAsync(createPersonDto);

            return CreatedAtAction(nameof(GetById), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreatePersonDto createPersonDto)
        {
            await _personService.UpdateAsync(id, createPersonDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _personService.DeleteAsync(id);
            return NoContent();
        }
    }

}
