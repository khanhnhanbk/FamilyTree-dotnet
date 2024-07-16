using FamilyTree.Data;
using FamilyTree.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<People>>> GetAll()
        {
            return await _context.Peoples.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetById(int id)
        {
            var people = await _context.Peoples.FindAsync(id);

            if (people == null)
            {
                return NotFound();
            }

            return people;
        }

        [HttpPost]
        public async Task<ActionResult<People>> AddPeople(People people)
        {
            _context.Peoples.Add(people);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeople", new { id = people.Id }, people);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePeople(People people)
        {   
            var dbPeople = await _context.Peoples.FindAsync(people.Id);
            if (dbPeople == null)
            {
                return NotFound();
            }

            dbPeople.Name = people.Name;
            dbPeople.BirthDate = people.BirthDate;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeople(int id)
        {
            var people = await _context.Peoples.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            _context.Peoples.Remove(people);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
