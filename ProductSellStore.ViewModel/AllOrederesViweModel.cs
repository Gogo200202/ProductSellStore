using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellStore.ViewModel
{
    public class AllOrederesViweModel
    {
        public int Id { get; set; }

        
        public int ItemId { get; set; }

        public Item Item { get; set; }


        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
