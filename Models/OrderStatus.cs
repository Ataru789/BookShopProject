﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Models
{
    [Table("OrderStatus")]
    /// <summary>
    /// Model przechowujący informacje o statusach zamówień
    /// </summary>
    public class OrderStatus
    {
        public int Id { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? StatusName { get; set; }


    }
}
