using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.DTOs.Stock;
using ApiBackend.Models;

namespace ApiBackend.Mappers.StockMappers
{
    //make the class static t make it extensible from the model
    public static class StockMapper
    {
        // map the stock model to the stock dto
        public static StockDto MapToDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbols = stock.Symbols,
                Purchase = stock.Purchase,
                Divident = stock.Divident,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }
    }
}