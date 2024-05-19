using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Services;
using TimeTracker.Domain.Dtos.TimeEntry;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public sealed class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
    {
        [HttpGet("{skip:int}/{take:int}")]
        public async Task<ActionResult<List<TimeEntryResponseDto>>> GetTimeEntries(int skip, int take)
        {
            return Ok(await timeEntryService.GetTimeEntriesAsync(skip, take));
        }

        [HttpGet]
        public async Task<ActionResult<TimeEntryResponseWrapperDto>> GetAllTimeEntries(int skip, int take)
        {
            return Ok(await timeEntryService.GetAllTimeEntriesAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimeEntryResponseDto>> GetTimeEntryById(int id)
        {
            TimeEntryResponseDto? result = await timeEntryService
                .GetTimeEntryByIdAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("project/{projectId:int}")]
        public async Task<ActionResult<List<TimeEntryResponseDto>>> GetTimeEntriesByProjectId(int projectId)
        {
            List<TimeEntryResponseDto>? result = await timeEntryService
                .GetTimeEntriesByProjectIdAsync(projectId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<TimeEntryResponseDto>>> CreateTimeEntry(TimeEntryCreateDto timeEntry)
        {
            return Ok(await timeEntryService
                .CreateTimeEntryAsync(timeEntry));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TimeEntryResponseDto>>> UpdateTimeEntry(int id, TimeEntryUpdateDto timeEntry)
        {
            List<TimeEntryResponseDto>? result = await timeEntryService
                .UpdateTimeEntryAsync(id, timeEntry);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TimeEntryResponseDto>>> DeleteTimeEntry(int id)
        {
            List<TimeEntryResponseDto>? result = await timeEntryService.DeleteTimeEntryAsync(id);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
