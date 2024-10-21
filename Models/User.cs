using System.ComponentModel.DataAnnotations;

namespace ASPNET6.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required]
    public int? OrderVolume { get; set; }
    
    public ICollection<Order>? Orders { get; set; }
}