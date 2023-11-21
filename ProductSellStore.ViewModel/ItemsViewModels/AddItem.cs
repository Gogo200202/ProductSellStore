using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ProductSellStore.ViewModel.ItemsViewModels
{
    public class AddItemViewModel
    {


        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]

        public string Description { get; set; } = null!;
        

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }



        [Required]
        [Url]
        public string PhotoUrl { get; set; }

        [Required]
        public int Category { get; set; }

        public ICollection<Category> Categorys { get; set; } = null!;

    }
}
