namespace BookShop.Repositories
{
    /// <summary>
    /// Jest to interfejs, który definiuje metody do zarządzania koszykiem
    /// </summary>
    public interface ICartRepository
    {
        Task<int> AddItem(int bookId, int qty);
        Task<int> RemoveItem(int bookId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout(CheckoutModelDTO model);
    }
}
