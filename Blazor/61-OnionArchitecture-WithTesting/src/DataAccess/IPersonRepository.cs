using Domain.Models;

namespace DataAccess;

public interface IPersonRepository
{
    Task<List<Person>> GetAllPersonsAsync();
    Task<Person?> GetPersonByIdAsync(int id);
    Task<Person?> CreatePersonAsync(PersonDto person);
    Task<Person?> UpdatePersonByIdAsync(int id, PersonDto person);
    Task<bool> DeletePersonByIdAsync(int id);
}
