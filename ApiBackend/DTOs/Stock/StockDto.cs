using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.DTOs.Comment;
using ApiBackend.Models;

namespace ApiBackend.DTOs.Stock
{
    public class StockDto
    {
       // pass all the sock model attributes
        public int Id { get; set; }
        public string Symbols { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal Divident { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; } = []; 
    }
}