using BlazorSyncfusion.Server.Data;
using BlazorSyncfusion.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusion.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("map")]
        public async Task<ActionResult<List<Department>>> GetMappedDepartments()
        {
            return await _context.Departments
                .Where(c => c.Latitude != null && c.Longitude != null)
                .ToListAsync();
        }
    }
}