using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Mappers.CommentMappers;
using ApiBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Conrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
       //pass the db context here
        public readonly CommentRepo _repo;
        public CommentController(CommentRepo repo)
        {
            _repo = repo;
        }
        //get all the comments
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _repo.GetCommentsAsync();
            var comment = comments.Select(comment => comment.MapToModel());
            return Ok(comment);
        }

        //get by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _repo.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.MapToModel());
        }
    }
    
    
    

}