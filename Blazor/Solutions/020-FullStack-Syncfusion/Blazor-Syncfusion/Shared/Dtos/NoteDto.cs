using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSyncfusion.Shared.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeNickName { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}