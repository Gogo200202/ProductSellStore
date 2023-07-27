using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProductSellStore.Data.Models;
using ProductSellStore.Data.Models.Enums;


namespace Models
{
    public class Orders {

        public Orders()
        {
            OrderOn = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string? Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }



        public string? Description { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [ForeignKey(nameof(User))]

        public string UserId  { get; set; }

        public ApplicationUser User { get; set; }

        public Status.OrderEnum OrderStatus { get; set; }

        public DateTime OrderOn { get; set; }


    }
}
