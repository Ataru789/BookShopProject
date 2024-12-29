using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.Controllers;

[Authorize(Roles = nameof(Roles.Admin))]
public class AdminController : Controller
{
    private readonly IUserOrderRepository _userOrderRepository;

    public AdminController(IUserOrderRepository userOrderRepository) 
    {
        _userOrderRepository = userOrderRepository;
    }
    
    public async Task<IActionResult> AllOrders() 
    {
        var orders = await _userOrderRepository.UserOrders(true);
        return View(orders);
    }

    public async Task<IActionResult> TogglePaymentStatus(int orderId) 
    {
        try
        {
            await _userOrderRepository.TogglePaymentStatus(orderId);
        }
        catch (Exception ex) { }
        return RedirectToAction(nameof(AllOrders));
    }

    public async Task<IActionResult> UpdateOrderStatus(int orderId) 
    {
        var order = await _userOrderRepository.GetOrderById(orderId);
        if (order == null) 
        {
            throw new InvalidOperationException($"Order with id:{orderId} does not found.");
        }
        var orderStatusList = (await _userOrderRepository.GetOrderStatuses()).Select(orderStatus =>
        {
            return new SelectListItem { Value =
             orderStatus.Id.ToString(), Text =
             orderStatus.StatusName, Selected =
             order.OrderStatusId == orderStatus.Id };
        });

        var data = new UpdateOrderStatusModel
        {
            OrderId = orderId,
            OrderStatusId = order.OrderStatusId,
            OrderStatusList = orderStatusList
        };
        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateOrderStatus(UpdateOrderStatusModel data) 
    {
        try
        {
            if (!ModelState.IsValid)
            {
                data.OrderStatusList = (await _userOrderRepository.GetOrderStatuses()).Select(orderStatus =>
                {
                    return new SelectListItem
                    {
                        Value =
                        orderStatus.Id.ToString(),
                        Text =
                        orderStatus.StatusName,
                        Selected =
                        orderStatus.Id == data.OrderStatusId
                    };
                });
                return View(data);
            }
            await _userOrderRepository.ChangeOrderStatus(data);
            TempData["msg"] = "Success";
        }
        catch (Exception ex) 
        {
            TempData["msg"] = "Not good";    
        }
        return RedirectToAction(nameof(UpdateOrderStatus), new {orderId = data.OrderId });
    }
}
