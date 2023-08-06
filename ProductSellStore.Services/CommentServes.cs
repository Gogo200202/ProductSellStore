using ProductSellStore.Data;
using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using ProductSellStore.ViewModel.ComnetsViewModels;

namespace ProductSellStore.Services
{
    public class CommentServes : ICommentServes
    {
        private readonly ProductSellStoreDbContext _context;
        public CommentServes(ProductSellStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<AllComentViewModel>> AllCommentForThisItem(int itemId)
        {
            var allcometns = await _context
                .ItemComments
                .Where(x => x.ItemId == itemId)
                .Select(x=>new AllComentViewModel()
                {
                    Id=x.Id,
                    UserId = x.UserId,
                    UserName = x.UserName,
                    ItemId = x.ItemId,
                    comment = x.Comment


                })
                .ToListAsync();

            return allcometns;
            
        }

        public async Task<bool> checkIfUserMakesThatComment(string userId, int commentId)
        {
            var resolt = await _context.ItemComments.AnyAsync(x=>x.UserId== userId&&x.Id==commentId);
            return resolt;
        }

        public async Task DeleteComment(int commentId)
       {
           var comennt = await _context.ItemComments.FindAsync(commentId);

           _context.ItemComments.Remove(comennt);
           await _context.SaveChangesAsync();
       }

       public async Task UserMakesComment(string userName,string userId, int itemId,string comment)
        {
            ItemComments itemComments = new ItemComments();
            itemComments.UserId = userId;
            itemComments.ItemId = itemId;
            itemComments.Comment = comment;
            itemComments.UserName=userName;

            await _context.ItemComments.AddAsync(itemComments);
            await _context.SaveChangesAsync();

            
        }
    }
}
