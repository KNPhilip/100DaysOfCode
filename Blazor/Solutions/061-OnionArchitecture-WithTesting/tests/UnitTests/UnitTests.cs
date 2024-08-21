using Application;
using AutoFixture;
using Concretions.Application;
using DataAccess;
using Domain.Models;
using ErrorOr;
using Mapster;
using NSubstitute;

namespace UnitTests;

public sealed class UnitTests
{
    private readonly IFixture _fixture = new Fixture();

    [Fact]
    public async Task GetPersonByIdAsync_WhenGivenCorrectId_ReturnsCorrectPerson()
    {
        // Arrange
        IPersonRepository personRepository = Substitute.For<IPersonRepository>();
        IPersonService personService = new PersonService(personRepository);
        Person expectedPerson = _fixture.Create<Person>();
        personRepository.GetPersonByIdAsync(expectedPerson.Id)
            .Returns(expectedPerson);

        // Act
        ErrorOr<PersonDto> actual = await personService.GetPersonByIdAsync(expectedPerson.Id);

        // Assert
        Assert.False(actual.IsError);
        Assert.Equivalent(expectedPerson.Adapt<PersonDto>(), actual.Value);
    }
}