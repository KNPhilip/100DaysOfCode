using Application;
using DataAccess;
using Domain.Models;
using ErrorOr;
using Mapster;

namespace Concretions.Application;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    private readonly IPersonRepository _personRepository = personRepository;

    public async Task<ErrorOr<List<Person>>> GetAllPersonsAsync()
    {
        List<Person>? personList = await _personRepository.GetAllPersonsAsync();
        if (personList is null || personList.Count == 0)
        {
            return Error.NotFound(description: "No people was found.");
        }
        return personList;
    }

    public async Task<ErrorOr<PersonDto>> GetPersonByIdAsync(int id)
    {
        Person? person = await _personRepository.GetPersonByIdAsync(id);
        if (person is null)
        {
            return Error.NotFound(description: $"""Person with id "{id}" was not found.""");
        }
        return person.Adapt<PersonDto>();
    }

    public async Task<ErrorOr<Person>> CreatePersonAsync(PersonDto person)
    {
        Person? createdPerson = await _personRepository.CreatePersonAsync(person);
        if (createdPerson is null)
        {
            return Error.Failure(description: "The person couldn't be created in the database.");
        }
        return createdPerson;
    }

    public async Task<ErrorOr<PersonDto>> UpdatePersonByIdAsync(int id, PersonDto person)
    {
        Person? updatedPerson = await _personRepository.UpdatePersonByIdAsync(id, person);
        if (updatedPerson is null)
        {
            return Error.Failure(description: $"""Person with id "{id}" could not be updated.""");
        }
        return updatedPerson.Adapt<PersonDto>();
    }

    public async Task<ErrorOr<bool>> DeletePersonByIdAsync(int id)
    {
        bool isDeleted = await _personRepository.DeletePersonByIdAsync(id);
        if (isDeleted is false)
        {
            return Error.Failure(description: $"""Person with id "{id}" could not be deleted.""");
        }
        return true;
    }
}
