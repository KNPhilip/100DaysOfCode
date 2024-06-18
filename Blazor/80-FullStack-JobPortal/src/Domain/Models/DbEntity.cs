namespace Domain.Models;

public class DbEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsSoftDeleted { get; set; }
}
