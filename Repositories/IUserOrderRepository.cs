namespace BookShop.Repositories
{
    /// <summary>
    /// Jest to interfejs, który definiuje metody do zarządzania zamówieniami użytkownika
    /// </summary>
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders(bool getAll = false);

        Task ChangeOrderStatus(UpdateOrderStatusModel data);

        Task TogglePaymentStatus(int orderId);

        Task<Order?> GetOrderById(int id);

        Task<IEnumerable<OrderStatus>> GetOrderStatuses();
    }
        
}