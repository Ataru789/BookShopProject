using System.ComponentModel.DataAnnotations;

namespace BookShop.Models.DTOs;

public class CheckoutModel
{
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    public string? MobileNumber { get; set; }

    [Required]
    [MaxLength(250)]
    public string? Address { get; set; }

    [Required]

    public string? PaymentMethod { get; set; }
}
