using System.ComponentModel.DataAnnotations;

namespace ASPNET6.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
}