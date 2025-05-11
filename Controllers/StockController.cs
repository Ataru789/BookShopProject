using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers

{
    [Authorize(Roles=nameof(Roles.Admin))]
    /// <summary>
    /// Kontroler odpowiedzialny za zarządzanie stanem książek
    /// </summary>  
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepo;

        public StockController(IStockRepository stockRepo)
        {
            _stockRepo = stockRepo; 
        }
        public async Task<IActionResult> Stock(string sTerm="")
        {
            var stocks = await _stockRepo.GetStocks(sTerm);
            return View(stocks);
        }

        public async Task<IActionResult> ManageStock(int bookId) 
        {
            var existingStock = await _stockRepo.GetStockBookById(bookId);
            var stock = new StockDTO
            {
                BookId = bookId,
                Quantity = existingStock != null ? existingStock.Quantity : 0
            };
            return View(stock);
        }

        [HttpPost]
        public async Task<IActionResult> ManageStock(StockDTO stock)
        {
            if (!ModelState.IsValid)
                return View(stock);
            try
            {
                await _stockRepo.ManageStock(stock);
                TempData["msg"] = "Update done"; 
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Update failed";
            }
            return RedirectToAction(nameof(Stock));
        }
    }
}
