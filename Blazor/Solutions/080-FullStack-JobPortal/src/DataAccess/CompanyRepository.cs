using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Domain.Models;

namespace DataAccess;

public class CompanyRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public virtual async Task<List<Company>> GetAllCompaniesAsync()
    {
        return await _context.Companies.ToListAsync() ?? [];
    }

    public virtual async Task<Company?> GetCompanyByIdAsync(int id)
    {
        return await _context.Companies.FirstOrDefaultAsync(u => u.Id == id);
    }

    public virtual async Task CreateCompanyAsync(Company company)
    {
        await _context.Companies.AddAsync(company.Adapt<Company>());
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateCompanyByIdAsync(Company newCompany)
    {
        Company? company = await _context.Companies.FindAsync(newCompany.Id)
            ?? throw new Exception($"Company with id {newCompany.Id} does not exist.");

        company = newCompany.Adapt(company);

        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteCompanyByIdAsync(int id)
    {
        Company? company = await _context.Companies.FindAsync(id)
            ?? throw new Exception($"Company with id {id} does not exist.");

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    }
}
