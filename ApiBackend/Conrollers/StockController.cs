using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Data;
using ApiBackend.DTOs.Stock;
using ApiBackend.Mappers.StockMappers;
using ApiBackend.Repositories;
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
    //   public readonly AppDbContext _context; //make the dbcontext only to be read onlyt
      //implement the stockrepo db context here
      public readonly StockRepo _repo;
      //AppDbContext context 
      public StockController(StockRepo repo)//get the dbcontext
      { 
           _repo = repo;
        //   _context = context;
      }

        //get all the stocks using the IActionResult
        [HttpGet]
        public async Task<IActionResult>  GetStocks()
        {
            var stocks = await  _repo.GetStockAsync();
            var stock = stocks.Select(stock =>stock.MapToDto());
            return Ok(stocks);
        }
       // get one result using id and IAction class

         [HttpGet("{id}")]
       public async Task<IActionResult> GetStock(int id)
       {
           var stock = await  _repo.GetStockByIdAsync(id);
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
                await _repo.CreateStockAsync(stock);
                
              return CreatedAtAction(nameof(GetStock), new {id = stock.Id}, stock.MapToDto());
         }

         //UPDATE stock using the IAction class and return the updated result
            [HttpPut("{id}")]
            public async  Task<IActionResult> UpdateStock(int id, [FromBody] CreateStockDto stockDtoS)
            {
                var stock = await _repo.UpdateStockAsync(id, stockDtoS);
                if (stock == null)
                {
                    return NotFound();
                }
            
                await _repo.UpdateStockAsync(id, stockDtoS);
                return Ok(stock.MapToDto());
            }
       
            //Delete stock using the IAction and async class and return successfully deleted as a message
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteStock(int id)
            {
                var stock = await _repo.DeleteStockAsync(id);
                if (stock == null)
                {
                    return NotFound();
                }
               
                return Ok("Successfully deleted");
            }
            
         
     
    }

  

}