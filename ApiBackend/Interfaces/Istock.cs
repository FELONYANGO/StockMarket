using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.DTOs.Stock;
using ApiBackend.Models;

namespace ApiBackend.Properties.Interfaces
{
    public interface Istock
    {
        //get the stock list using async
        Task<List<Stock>> GetStockAsync();
       //implement the get stock by id
         Task<Stock?> GetStockByIdAsync(int id);
            //implement the create stock
         Task<Stock?> CreateStockAsync(Stock stock);
            //implement the update stock
         Task<Stock?> UpdateStockAsync(int id, CreateStockDto stockDto);
            //implement the delete stock
         Task<Stock?> DeleteStockAsync(int id);
         //check if stock exist
         Task<bool> StockExists(int id);
      
    }
}