using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Data;
using ApiBackend.DTOs.Stock;
using ApiBackend.Models;
using ApiBackend.Properties.Interfaces;
using Microsoft.EntityFrameworkCore;
//import the mappers for the stockusing ApiBackend.Mappers.StockMappers;

namespace ApiBackend.Repositories
{
    public class StockRepo : Istock
    {
       //         public readonly AppDbContext _context;
        private readonly AppDbContext _context;
        public StockRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Stock?> CreateStockAsync(Stock stock)
        {
           await _context.Stocks.AddAsync(stock);
              await _context.SaveChangesAsync();
                return stock;
        }

        public async Task<Stock?> DeleteStockAsync(int id)
        {
           var stockmodel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
           if (stockmodel == null)
           {
               return null;
           }
              _context.Stocks.Remove(stockmodel);
                await _context.SaveChangesAsync();
                return stockmodel;

            
        }

        public async Task<List<Stock>> GetStockAsync()//get all stocks
        {
            return await _context.Stocks.Include(c=>c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetStockByIdAsync(int id) //get stock by id
        {
            var stock = await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(s => s.Id == id);
             if (stock == null)
             {
                 return null;
             }
                return stock;
             
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateStockAsync(int id, CreateStockDto stock) //update the stock
        {
            var tobeupdated =  await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            if (tobeupdated == null)
            {
                return null;
            }

            tobeupdated.Symbols = stock.Symbols;
            tobeupdated.Purchase = stock.Purchase;
            tobeupdated.Divident = stock.Divident;
            tobeupdated.Industry = stock.Industry;
            tobeupdated.MarketCap = stock.MarketCap;
            await _context.SaveChangesAsync();

            return tobeupdated;
        }

       
    }
}