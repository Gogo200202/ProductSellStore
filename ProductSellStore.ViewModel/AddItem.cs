using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ProductSellStore.ViewModel
{
    public class AddItemViewModel
    {
       

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]

        public string Description { get; set; } = null!;
        [Range(0, 5)]
        public int Rating { get; set; }

        [Required]
        public decimal Price { get; set; }



        [Required]
        public string PhotoUrl { get; set; }

        [Required]
        public int CategoreId { get; set; }

        public ICollection<Category> Categorys { get; set; } = null!;

    }
}
