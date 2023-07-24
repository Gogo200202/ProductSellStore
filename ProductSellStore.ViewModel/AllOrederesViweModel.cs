using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductSellStore.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductSellStore.ViewModel
{
    public class AllOrederesViweModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
   
        public string LastName { get; set; }

        public string? Email { get; set; }

        public string Address { get; set; }

    
        public string Country { get; set; }

        public string State { get; set; }

    
        public string Zip { get; set; }



        public string? Description { get; set; }


        public int ItemId { get; set; }

        public Item Item { get; set; }

        public Status.OrderEnum AllStatus { get; set; }


        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
