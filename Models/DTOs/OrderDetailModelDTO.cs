namespace BookShop.Models.DTOs;

/// <summary>
/// Przechowuje i przekazuje dane o szczegółach zamówienia
/// </summary>
public class OrderDetailModelDTO
{
    public string DivId { get; set; }

    public IEnumerable<OrderDetail> OrderDetails { get; set; }
}
