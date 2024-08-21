using BlazorSyncfusion.Server.Data;
using BlazorSyncfusion.Shared.Dtos;
using BlazorSyncfusion.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BlazorSyncfusion.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly DataContext _context;

        public NotesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<NoteDto>>> GetAllNotes()
        {
            var noteDto = await _context.Notes
            .Include(n => n.Employee)
            .OrderByDescending(n => n.DateCreated)
            .Select(n => new NoteDto
            {
                Id = n.Id,
                Text = n.Text,
                DateCreated = n.DateCreated,
                EmployeeId = n.Employee!.Id,
                EmployeeNickName = n.Employee.NickName
            })
            .ToListAsync();

            return noteDto;
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<List<Note>>> GetNotesFromEmployee(int employeeId)
        {
            return await _context.Notes
                .Where(n => n.EmployeeId == employeeId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<List<Note>>> CreateNote(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return await _context.Notes
                .Where(n => n.EmployeeId == note.EmployeeId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Note>>> DeleteNote(int id)
        {
            var dbNote = await _context.Notes.FindAsync(id);
            if (dbNote is null)
            {
                return NotFound("Note not found.");
            }

            _context.Notes.Remove(dbNote);
            await _context.SaveChangesAsync();

            return await _context.Notes
                .Where(n => n.EmployeeId == dbNote.EmployeeId)
                .OrderByDescending(n => n.DateCreated)
                .ToListAsync();
        }
    }
}