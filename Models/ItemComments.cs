using Microsoft.AspNetCore.Identity;
using ProductSellStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ItemComments
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        [Required] 
        public string UserName { get; set; }


        [Required] 
        public string Comment { get; set; }
        [ForeignKey(nameof(Item))]

        public int ItemId { get; set; }
        
        public Item Item { get; set; }
    }
}
