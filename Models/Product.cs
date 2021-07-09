using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(60)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductDesc { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
