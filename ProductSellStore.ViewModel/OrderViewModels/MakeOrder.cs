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

namespace ProductSellStore.ViewModel.OrderViewModels
{
    public class MakeOrder
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The First name must be 50 charecters long")]
        [MaxLength(50)]

        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "The Last name must be 50 charecters long")]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Not valid Email")]
        public string? Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string State { get; set; } = null!;

        [Required]
        [MaxLength(4)]
        public string Zip { get; set; } = null!;

        [Required]
        public int Amount { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        //public Item? Item { get; set; }

        

        //public ApplicationUser? User { get; set; }

        public Status.OrderEnum OrderStatus { get; set; }


    }
}
