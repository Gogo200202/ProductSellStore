using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [ForeignKey(nameof(User))]

        public string UserId  { get; set; }

        public IdentityUser User { get; set; }




    }
}
