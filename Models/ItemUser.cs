using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProductSellStore.Data.Models;

namespace Models
{
    public class ItemUser
    {
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [ForeignKey(nameof(User))]

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

    }
}
