using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.Models
{
    public class Comments
    {
        //attribbutes are :Id,StockId,Content ,Title,Date,And navigation to the stock model
        public int Id { get; set; }
        public int StockId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public Stock? Stock { get; set; }//navigation to the stock model
    }
}