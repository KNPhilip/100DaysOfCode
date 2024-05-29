using DataAccess;
using DataAccess.Data;
using Domain.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Concretions.DataAccess;

public sealed class PersonRepository(DataContext dbContext) : IPersonRepository
{
    public async Task<List<Person>> GetAllPersonsAsync()
    {
        return await dbContext.Persons.ToListAsync();
    }

    public async Task<Person?> GetPersonByIdAsync(int id)
    {
        return await dbContext.Persons.FindAsync(id);
    }

    public async Task<Person?> CreatePersonAsync(PersonDto person)
    {
        EntityEntry<Person> createdPerson = await dbContext.Persons.AddAsync(person.Adapt<Person>());
        await dbContext.SaveChangesAsync();
        return createdPerson.Entity;
    }

    public async Task<Person?> UpdatePersonByIdAsync(int id, PersonDto person)
    {
        Person? personToUpdate = await dbContext.Persons.FindAsync(id);
        if (personToUpdate is null)
        {
            return null;
        }
        personToUpdate.FirstName = person.FirstName;
        personToUpdate.LastName = person.LastName;
        personToUpdate.BirthDate = person.BirthDate;
        await dbContext.SaveChangesAsync();
        return personToUpdate;
    }

    public async Task<bool> DeletePersonByIdAsync(int id)
    {
        Person? personToDelete = await dbContext.Persons.FindAsync(id);
        if (personToDelete is null)
        {
            return false;
        }
        dbContext.Persons.Remove(personToDelete);
        return await dbContext.SaveChangesAsync() > 0;
    }
}
