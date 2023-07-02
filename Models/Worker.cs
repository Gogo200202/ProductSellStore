using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Worker
    {
        public Worker()
        {
            this.Id = new Guid();
        }
        [Key]
        public Guid Id { get; set; }

        public IdentityUser UserId { get; set; }
    }
}
