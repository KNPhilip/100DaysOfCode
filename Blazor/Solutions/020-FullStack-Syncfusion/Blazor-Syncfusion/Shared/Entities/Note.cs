using Newtonsoft.Json;

namespace BlazorSyncfusion.Shared.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}