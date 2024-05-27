using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Data;
using ApiBackend.Mappers.StockMappers;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Conrollers
{
    //route
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
     ///the stock 
      public readonly AppDbContext _context; //make the dbcontext only to be read only
      public StockController(AppDbContext context)
      {
          _context = context;
      }

        //get all the stocks using the IActionResult
        [HttpGet]
        public IActionResult GetStocks()
        {
            var stocks = _context.Stocks.ToList().Select(stock =>stock.MapToDto());
            return Ok(stocks);
        }
       // get one result using id and IAction class

         [HttpGet("{id}")]
       public IActionResult GetStock(int id)
       {
           var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
           if (stock == null)
           {
               return NotFound();
           }
           return Ok(stock.MapToDto());
       }
     
    }
}