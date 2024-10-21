using System.ComponentModel.DataAnnotations;

namespace ASPNET6.Models;

public class Order
{
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public User Customer { get; set; }
    public List<Product> Products { get; set; }
}