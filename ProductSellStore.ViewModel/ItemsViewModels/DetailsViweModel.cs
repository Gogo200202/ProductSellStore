using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductSellStore.ViewModel.ComnetsViewModels;

namespace ProductSellStore.ViewModel.ItemsViewModels
{
    public class DetailsViweModel
    {
        public DetailsViweModel()
        {
            AllComents = new List<AllComentViewModel>();
        }
        public int Id { get; set; }


        public string Name { get; set; } = null!;


        public string Description { get; set; } = null!;

        public int Rating { get; set; }


        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }

        public int CategoreId { get; set; }

        public Category Category { get; set; } = null!;

        public List<AllComentViewModel> AllComents { get; set; }

    }
}
