using Application;
using Domain.Models;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class PersonController(IPersonService personService) : ControllerBase
{
    private readonly IPersonService _personService = personService;

    [HttpGet]
    public async Task<ActionResult<List<Person>>> GetAllPersonsAsync()
    {
        ErrorOr<List<Person>> personList = await _personService.GetAllPersonsAsync();
        if (personList.IsError)
        {
            return Ok(new List<Person>() { });
        }
        return Ok(personList.Value ?? []);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Person>> GetPersonByIdAsync(int id)
    {
        ErrorOr<PersonDto> personList = await _personService.GetPersonByIdAsync(id);
        if (personList.IsError)
        {
            return NotFound(personList.Errors);
        }
        return Ok(personList.Value);
    }

    [HttpPost]
    public async Task<ActionResult<Person>> CreatePersonAsync(PersonDto person)
    {
        ErrorOr<Person> createdPerson = await _personService.CreatePersonAsync(person);
        if (createdPerson.IsError)
        {
            return NotFound("Something went wrong: " + createdPerson.Errors);
        }
        return Ok(createdPerson.Value);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<PersonDto>> UpdatePersonByIdAsync(int id, PersonDto person)
    {
        ErrorOr<PersonDto> updatedPerson = await _personService.UpdatePersonByIdAsync(id, person);
        if (updatedPerson.IsError)
        {
            return BadRequest("Something went wrong: " + updatedPerson.Errors);
        }
        return Ok(updatedPerson.Value);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<bool>> DeletePersonByIdAsync(int id)
    {
        ErrorOr<bool> result = await _personService.DeletePersonByIdAsync(id);
        if (result.IsError || result.Value is false)
        {
            return BadRequest("Something went wrong: " + result.Errors);
        }
        return NoContent();
    }
}
