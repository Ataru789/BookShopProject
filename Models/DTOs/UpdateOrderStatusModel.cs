﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookShop.Models.DTOs;

public class UpdateOrderStatusModel
{
    public int OrderId { get; set; }

    [Required]
    public int OrderStatusId { get; set; }

    public IEnumerable<SelectListItem>? OrderStatusList { get; set; }
}