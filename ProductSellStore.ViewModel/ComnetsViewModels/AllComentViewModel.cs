using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellStore.ViewModel.ComnetsViewModels
{
    public class AllComentViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

        public int ItemId { get; set; }
        [MaxLength(150)]
        public string comment { get; set; }
    }
}
