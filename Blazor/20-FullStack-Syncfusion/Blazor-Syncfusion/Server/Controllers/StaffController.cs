using BlazorSyncfusion.Server.Data;
using BlazorSyncfusion.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlazorSyncfusion.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly DataContext _context;
        
        public StaffController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllStaff()
        {
            return Ok(await _context.Employees
                .Where(c => c.IsEmployee)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetStaffById(int id)
        {
            var result = await _context.Employees.FindAsync(id);
            if(result is null)
            {
                return NotFound("Staff not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateStaff(Employee employee)
        {
            employee.IsEmployee = true;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateStaff(int id, Employee employee)
        {
            var dbStaff = await _context.Employees.FindAsync(id);
            if (dbStaff is null)
            {
                return NotFound("Staff not found.");
            }

            dbStaff.FirstName = employee.FirstName;
            dbStaff.LastName = employee.LastName;
            dbStaff.NickName = employee.NickName;
            dbStaff.Title = employee.Title;
            dbStaff.Mail = employee.Mail;
            dbStaff.Phone = employee.Phone ?? dbStaff.Phone;
            dbStaff.BirthDate = employee.BirthDate;
            dbStaff.DateLastUpdated = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteStaff(int id)
        {
            var dbStaff = await _context.Employees.FindAsync(id);
            if(dbStaff is null)
            {
                return NotFound("Staff not found.");
            }

            dbStaff.IsEmployee = false;
            dbStaff.DateLastUpdated = DateTime.Now;
            dbStaff.DateFired = DateTime.Now;

            await _context.SaveChangesAsync();

            return await GetAllStaff();
        }
    }
}