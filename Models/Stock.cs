using System.ComponentModel.DataAnnotations.Schema;
namespace BookShop.Models;

[Table("Stock")]
/// <summary>
/// Model przechowujący informacje o ilości dostępnych książek
/// </summary>
public class Stock
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public Book? Book { get; set; }

}
