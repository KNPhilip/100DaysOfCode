using Domain.Models;
using ErrorOr;

namespace Application;

public interface IPersonService
{
    Task<ErrorOr<List<Person>>> GetAllPersonsAsync();
    Task<ErrorOr<PersonDto>> GetPersonByIdAsync(int id);
    Task<ErrorOr<Person>> CreatePersonAsync(PersonDto person);
    Task<ErrorOr<PersonDto>> UpdatePersonByIdAsync(int id, PersonDto person);
    Task<ErrorOr<bool>> DeletePersonByIdAsync(int id);
}
