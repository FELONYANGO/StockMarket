using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.DTOs.Comment;
using ApiBackend.Models;

namespace ApiBackend.Mappers.CommentMappers
{
    public static class CommentMapper
    {
        //mapp the comment Dto to the comment model
        public static CommentDto  MapToModel(this Comments commentDto)
        {
            return new CommentDto
            {
                Id = commentDto.Id,
                StockId = commentDto.StockId,
                Content = commentDto.Content,
                Title = commentDto.Title
            };
        }

        // create comment mapper for createcommentDto
        public static Comments MapToCreate(this CreateCommentDto createCommentDtos, int stockId)
        {
            return new Comments
            {
                StockId = stockId,
                Content = createCommentDtos.Content,
                Title = createCommentDtos.Title
            };
        }
        //update comment mapper
        
        public static Comments MapToUpdate(this UpdateDto updateDto)
        {
            return new Comments
            {
                Content = updateDto.Content,
                Title = updateDto.Title
            };
        }
        
   
    }
}