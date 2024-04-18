using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class CategoriesEntity
{
    [Key]
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
}
