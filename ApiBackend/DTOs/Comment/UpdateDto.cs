using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.DTOs.Comment
{
    public class UpdateDto
    {
        
        public string Content { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
    }
}