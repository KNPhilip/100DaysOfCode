using ErrorOr;
using Interactors.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.V1;

public sealed class CompanyV1Controller(CompanyInteractor companyInteractor) : V1ControllerTemplate
{
    private readonly CompanyInteractor _companyInteractor = companyInteractor;

    [HttpGet]
    public async Task<ActionResult<List<Domain.Models.Company>>> GetAllCompaniesAsync()
    {
        return await _companyInteractor.GetAllCompaniesAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Domain.Models.Company>> GetCompanyByIdAsync(int id)
    {
        ErrorOr<Domain.Models.Company> Company = await _companyInteractor.GetCompanyByIdAsync(id);
        if (Company.IsError)
        {
            return NotFound(Company.Errors.FirstOrDefault());
        }
        return Ok(Company.Value);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCompanyAsync(Domain.Models.Company company)
    {
        ErrorOr<bool> result = await _companyInteractor.CreateCompanyAsync(company);
        if (result.IsError)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateCompanyAsync(int id, Domain.Models.Company company)
    {
        company.Id = id;
        ErrorOr<bool> result = await _companyInteractor.UpdateCompanyByIdAsync(company);
        if (result.IsError)
        {
            return BadRequest(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCompanyAsync(int id)
    {
        ErrorOr<bool> result = await _companyInteractor.DeleteCompanyByIdAsync(id);
        if (result.IsError)
        {
            return NotFound(result.Errors.FirstOrDefault());
        }
        return NoContent();
    }
}
