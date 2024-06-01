using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.DTOs.Comment;
using ApiBackend.DTOs.Stock;
using ApiBackend.Interfaces;
using ApiBackend.Mappers.CommentMappers;
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
                MarketCap = stock.MarketCap,
                //add the comments the comment lists form the 
                Comments = stock.Comments.Select(comment => comment.MapToModel() ).ToList()
                
            };
        }

        //map the stock from CreateStockDto to the stock model
        public static Stock MapToModel(this CreateStockDto stockDto)
        {
            return new Stock
            {
                Symbols = stockDto.Symbols,
                Purchase = stockDto.Purchase,
                Divident = stockDto.Divident,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
    }
}