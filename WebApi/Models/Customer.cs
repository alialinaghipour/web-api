using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Customer
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = default!;
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = default !;
    [Required]
    [EmailAddress]
    public string Email { get; set; }= default !;
}