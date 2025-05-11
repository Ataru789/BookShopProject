using Microsoft.EntityFrameworkCore;



namespace BookShop.Repositories
{
    /// <summary>
    /// Jest to interfejs, który definiuje metody do zarządzania ilością dostępnych książek
    /// </summary>
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<Stock?> GetStockBookById(int bookId) => await
            _context.Stocks.FirstOrDefaultAsync(s => s.BookId == bookId);

        public async Task ManageStock(StockDTO stockToManage) 
        {
            var existingStock = await GetStockBookById(stockToManage.BookId);
            if (existingStock is null) 
            {
                var stock = new Stock { BookId = stockToManage.BookId, Quantity = stockToManage.Quantity };
                _context.Stocks.Add(stock);
            }
            else
            {
                existingStock.Quantity = stockToManage.Quantity;
            }
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm="")
        {
            var stocks = await (from book in _context.Books
                                join stock in _context.Stocks
                                on book.Id equals stock.BookId
                                into book_stock
                                from bookStock in book_stock.DefaultIfEmpty()
                                where string.IsNullOrWhiteSpace(sTerm) ||
                                book.Title.ToLower().Contains(sTerm.ToLower())
                                select new StockDisplayModel
                                {
                                    BookId = book.Id,
                                    Title = book.Title,
                                    Quantity = bookStock == null ? 0 : bookStock.Quantity
                                }).ToListAsync();
            return stocks;
        }
    }

    public interface IStockRepository
    {
        Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm="");
        Task<Stock?> GetStockBookById(int bookId);
        Task ManageStock(StockDTO stockToManage);

    }
}
