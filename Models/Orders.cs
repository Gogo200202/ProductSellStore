using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProductSellStore.Data.Models;



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
        [MaxLength(50)]

        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [MaxLength(4)]
        public string Zip { get; set; }

        [Required]
        public int Amount { get; set; }


        [MaxLength(500)]
        public string? Description { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [ForeignKey(nameof(User))]

        public string UserId  { get; set; }

        public ApplicationUser User { get; set; }


        public DateTime OrderOn { get; set; }


    }
}
