using FamilyTree.DTOs;

namespace FamilyTree.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync();
        Task<PersonDto> GetByIdAsync(int id);
        Task<PersonDto> CreateAsync(CreatePersonDto createPersonDto);
        Task UpdateAsync(int id, CreatePersonDto createPersonDto);
        Task DeleteAsync(int id);
    }
}
