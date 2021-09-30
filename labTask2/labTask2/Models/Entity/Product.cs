using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace labTask2.Models.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Required")]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
    }
}