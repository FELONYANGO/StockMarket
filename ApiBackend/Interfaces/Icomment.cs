using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Models;

namespace ApiBackend.Interfaces
{
    public interface Icomment
    {
        //List all comments
        Task<List<Comments>> GetCommentsAsync();
        //get by id
        Task<Comments?> GetCommentByIdAsync(int id);

        //create comment
        Task<Comments> CreateCommentAsync(Comments comment);
       //update comment
        Task<Comments?> UpdateCommentAsync(int id, Comments comment);
        //delete comment
        Task<Comments?> DeleteCommentAsync(int id);

    }
}