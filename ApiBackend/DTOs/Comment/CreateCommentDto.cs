using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.DTOs.Comment
{
    public class CreateCommentDto
    {
        //validate to create required and min lenth of 5 character with error message
        [Required]
        [StringLength(5), MinLength(5, ErrorMessage = "Content must be at least 5 characters long")]
        public string Content { get; set; } = string.Empty;
         
          [Required]
        [StringLength(280), MaxLength(280, ErrorMessage = "Content must be at most 280 characters long")]
        public string Title { get; set; } = string.Empty;
    }
}