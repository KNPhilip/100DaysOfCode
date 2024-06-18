using DataAccess;
using ErrorOr;

namespace Interactors.Company;

public sealed class CompanyInteractor(CompanyRepository companyRepository)
{
    private readonly CompanyRepository _companyRepository = companyRepository;


    public async Task<List<Domain.Models.Company>> GetAllCompaniesAsync()
    {
        return await _companyRepository.GetAllCompaniesAsync() ?? [];
    }

    public async Task<ErrorOr<Domain.Models.Company>> GetCompanyByIdAsync(int id)
    {
        Domain.Models.Company? company = await _companyRepository.GetCompanyByIdAsync(id);
        if (company is null)
        {
            return Error.NotFound($"Company with id {id} does not exist.");
        }
        return company;
    }

    public async Task<ErrorOr<bool>> CreateCompanyAsync(Domain.Models.Company company)
    {
        try
        {
            await _companyRepository.CreateCompanyAsync(company);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }

    public async Task<ErrorOr<bool>> UpdateCompanyByIdAsync(Domain.Models.Company company)
    {
        try
        {
            await _companyRepository.UpdateCompanyByIdAsync(company);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }

    public async Task<ErrorOr<bool>> DeleteCompanyByIdAsync(int id)
    {
        try
        {
            await _companyRepository.DeleteCompanyByIdAsync(id);
            return true;
        }
        catch (Exception e)
        {
            return Error.NotFound(e.Message);
        }
    }
}
