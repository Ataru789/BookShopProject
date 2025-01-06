namespace BookShop.Models
{
    /// <summary>
    /// Model przechowujacy informacje o bledach
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
