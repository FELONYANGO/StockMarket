using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.DTOs.Stock
{
    public class CreateStockDto 
    {
        [Required]
        [StringLength(5, ErrorMessage = "Symbols must be at least 5 characters long")]
        public string Symbols { get; set; }=string.Empty;
        [Required]
        [Range(3, 5, ErrorMessage = "The length of the purchase must be between 3 and 5")]
        public decimal Purchase { get; set; }
        [Required]
        [Range(3, 5, ErrorMessage = "The length of the divident must be between 3 and 5")]
        public decimal Divident { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "The length of the industry name must be at least 5 characters long")]
        public string Industry { get; set; }=string.Empty;
        [Required]
        [Range(0, 100000, ErrorMessage = "The length of the market cap must be between 3 and 5")]
        public long MarketCap { get; set; }
    }

    
}