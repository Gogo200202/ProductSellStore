using ProductSellStore.ViewModel.ComnetsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellStore.Interface
{
    public interface ICommentServes
    {
        public Task UserMakesComment(string userName, string userId,int itemId,string comment);
        public Task DeleteComment(int commentId);
        public Task<List<AllComentViewModel>> AllCommentForThisItem(int itemId);

    }
}
