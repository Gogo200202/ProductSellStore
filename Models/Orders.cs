﻿using System;
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
