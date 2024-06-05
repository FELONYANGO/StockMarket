using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBackend.DTOs.Comment
{
    public class UpdateDto
    {
        [Required]
        [StringLength(280),MaxLength(280,ErrorMessage="the string must of 280 words")]
        public string Content { get; set; } = string.Empty;
        [Required]
        [StringLength(5),MinLength(280,ErrorMessage ="the string must have 5 character minimum length")]
        public string Title { get; set; } = string.Empty;
    }
}