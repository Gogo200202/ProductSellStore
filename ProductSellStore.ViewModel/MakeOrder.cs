using Models;
using ProductSellStore.Data.Models.Enums;
using ProductSellStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellStore.ViewModel
{
    public class MakeOrder
    {
       
        [Key]
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public string Description { get; set; }

        public Item Item { get; set; }

        [ForeignKey(nameof(User))]

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public Status.OrderEnum OrderStatus { get; set; }

       
    }
}
