using FamilyTree.Data;
using FamilyTree.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyTree.Repositories
{

    public class PersonRepository : IPersonRepository
    {
        private readonly FamilyTreeContext _context;
        public PersonRepository(FamilyTreeContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task AddAsync(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.People.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
