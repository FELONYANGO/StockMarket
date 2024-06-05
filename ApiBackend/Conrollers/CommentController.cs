using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.DTOs.Comment;
using ApiBackend.Mappers.CommentMappers;
using ApiBackend.Properties.Interfaces;
using ApiBackend.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace ApiBackend.Conrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
       //pass the db context here
        private readonly CommentRepo _repo;
        private readonly StockRepo _stockrepo;

        public CommentController(CommentRepo repo, StockRepo repostock)
        {
            _repo = repo;
            _stockrepo = repostock;
            

        }
        //get all the comments
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _repo.GetCommentsAsync();
            var comment = comments.Select(comment => comment.MapToModel());
            return Ok(comment);
        }

        //get by id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetComment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _repo.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.MapToModel());
        }

        // create commnt attaching stock id and createcomentDto
        [HttpPost("{stockId:int}")]

        public async Task<IActionResult> CreateComment([FromRoute] int stockId, CreateCommentDto createCommentDto)
        {
           //check if stock exist
            if (!await _stockrepo.StockExists(stockId))
            {
                return BadRequest("Stock does not exist");
            }
            var comment = createCommentDto.MapToCreate(stockId);
            await _repo.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetComment), new {id = comment.Id}, comment.MapToModel());

        
            
        }
        // update usng as Id and updatecommentDto
        [HttpPut]
        //route
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id , UpdateDto updateCommentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _repo.UpdateCommentAsync(id, updateCommentDto.MapToUpdate());
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.MapToModel());

        }

        //delete comment
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _repo.DeleteCommentAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok("Successfully deleted");

        }
        
    }
    
    
    

}