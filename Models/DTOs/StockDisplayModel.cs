namespace BookShop.Models.DTOs
{
    /// <summary>
    /// Przechowuje i przekazuje dane o ilości dostępnych egzemplarzy książek
    /// </summary>
    public class StockDisplayModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public string? Title { get; set; }
    }
}
