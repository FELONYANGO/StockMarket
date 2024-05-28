using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Data;
using ApiBackend.DTOs.Stock;
using ApiBackend.Mappers.StockMappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult>  GetStocks()
        {
            var stocks = await _context.Stocks.ToListAsync();
            var stock = stocks.Select(stock =>stock.MapToDto());
            return Ok(stocks);
        }
       // get one result using id and IAction class

         [HttpGet("{id}")]
       public async Task<IActionResult> GetStock(int id)
       {
           var stock = await  _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
           if (stock == null)
           {
               return NotFound();
           }
           return Ok(stock.MapToDto());
       }

       //Post Stock using the IAction class
       [HttpPost]
         public async Task<IActionResult> CreateStock([FromBody] CreateStockDto stockDto)
         {
              var stock = stockDto.MapToModel();
              await _context.Stocks.AddAsync(stock);
              await _context.SaveChangesAsync();
              return CreatedAtAction(nameof(GetStock), new {id = stock.Id}, stock.MapToDto());
         }

         //UPDATE stock using the IAction class and return the updated result
            [HttpPut("{id}")]
            public async  Task<IActionResult> UpdateStock(int id, [FromBody] CreateStockDto stockDto)
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
                if (stock == null)
                {
                    return NotFound();
                }
                stock.Symbols = stockDto.Symbols;
                stock.Purchase = stockDto.Purchase;
                stock.Divident = stockDto.Divident;
                stock.Industry = stockDto.Industry;
                stock.MarketCap = stockDto.MarketCap;
               await _context.SaveChangesAsync();
                return Ok(stock.MapToDto());
            }
public async Task<IActionResult> CreateStock([FromBody] CreateStockDto stockDto)
         {
               var stock = stockDto.MapToModel();
               await _context.Stocks.AddAsync(stock);
               await _context.SaveChangesAsync();
               return CreatedAtAction(nameof(GetStock), new {id = stock.Id}, stock.MapToDto());
         }
            //Delete stock using the IAction and async class and return successfully deleted as a message
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteStock(int id)
            {
                var stock = await _context.Stocks.FindAsync(id);
                if (stock == null)
                {
                    return NotFound();
                }
                _context.Stocks.Remove(stock);
                await _context.SaveChangesAsync();
                return Ok("Successfully deleted");
            }
            
         
     
    }
}