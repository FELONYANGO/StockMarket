using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBackend.Data;
using ApiBackend.Interfaces;
using ApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBackend.Repositories
{
    
     
    //inherit the Icomment interface
    public class CommentRepo : Icomment

    {
        // brings the db context
        private readonly AppDbContext _context;
        public CommentRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Comments>> GetCommentsAsync()
        {
           return  await _context.Comments.ToListAsync();
        }
    }
}