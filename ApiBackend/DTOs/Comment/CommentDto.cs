using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.DTOs.Comment
{
    public class CommentDto
    {
        //validate to required
        // [Required]
        public int Id { get; set; }
        // validate to required A
        public int StockId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        

    }
}