using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.Models
{
    public class Stock
    {
        //attributes are :Id,Symbols,Purchase,Divident,Industry,MarketCap,array of the comment class
        public int Id { get; set; }
        
        public string Symbols { get; set; }=string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Divident { get; set; }
        public string Industry { get; set; }=string.Empty;
        public long MarketCap { get; set; }
        public List<Comments> Comments { get; set; } = [];
    }
}