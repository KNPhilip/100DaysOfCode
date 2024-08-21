using BlazorSyncfusion.Shared.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BlazorSyncfusion.Shared
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Indtast venligst et fornavn.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Indtast venligst et efternavn.")]
        public string LastName { get; set; } = string.Empty;
        public string FullName { get => FirstName + " " + LastName; }
        [Required(ErrorMessage = "Indtast venligst initialerne (F.eks. JEMA)")]
        public string NickName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Indsæt venligst en stilling.")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Indtast venligst en mail.")]
        public string Mail { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string School { get; set; } = string.Empty;
        public bool IsEmployee { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateHired { get; set; } = DateTime.Now;
        public DateTime? DateLastUpdated { get; set; }
        public DateTime? DateFired { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [JsonIgnore]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}