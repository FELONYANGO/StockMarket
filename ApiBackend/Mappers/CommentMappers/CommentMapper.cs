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
    }
}