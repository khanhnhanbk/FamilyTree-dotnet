using FamilyTree.DTOs;
using FamilyTree.Models;
using FamilyTree.Repositories;

namespace FamilyTree.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync()
        {
            var people = await _personRepository.GetAllAsync();
            return people.Select(p => new PersonDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                DateOfDeath = p.DateOfDeath,
                FatherId = p.FatherId,
                MotherId = p.MotherId,
                SpouseId = p.SpouseId
            }).ToList();
        }

        public async Task<PersonDto> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return null;
            }

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                DateOfDeath = person.DateOfDeath,
                FatherId = person.FatherId,
                MotherId = person.MotherId,
                SpouseId = person.SpouseId
            };
        }

        public async Task<PersonDto> CreateAsync(CreatePersonDto createPersonDto)
        {
            var person = new Person
            {
                FirstName = createPersonDto.FirstName,
                LastName = createPersonDto.LastName,
                DateOfBirth = createPersonDto.DateOfBirth,
                Gender = createPersonDto.Gender,
                DateOfDeath = createPersonDto.DateOfDeath,
                FatherId = createPersonDto.FatherId,
                MotherId = createPersonDto.MotherId,
                SpouseId = createPersonDto.SpouseId
            };

            await _personRepository.AddAsync(person);

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Gender = person.Gender,
                DateOfDeath = person.DateOfDeath,
                FatherId = person.FatherId,
                MotherId = person.MotherId,
                SpouseId = person.SpouseId
            };
        }
        public async Task UpdateAsync(int id, CreatePersonDto createPersonDto)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            {
                return;
            }

            person.FirstName = createPersonDto.FirstName;
            person.LastName = createPersonDto.LastName;
            person.DateOfBirth = createPersonDto.DateOfBirth;
            person.Gender = createPersonDto.Gender;
            person.DateOfDeath = createPersonDto.DateOfDeath;
            person.FatherId = createPersonDto.FatherId;
            person.MotherId = createPersonDto.MotherId;
            person.SpouseId = createPersonDto.SpouseId;

            await _personRepository.UpdateAsync(person);
        }

        public async Task DeleteAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
        }
    }
}
