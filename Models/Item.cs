﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]

        public string Description { get; set; } = null!;
        [Range(0,5)]
        public int Rating { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoreId { get; set; }
        [Required]
        public Category Category { get; set; } = null!;

        //implement feedback if you can 
    }
}
