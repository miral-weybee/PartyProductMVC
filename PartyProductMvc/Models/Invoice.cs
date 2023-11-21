using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyProductMvc.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Party Name")]
        public Party Party { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public Product Product { get; set; }

        [Required]
        [DisplayName("Current Rate")]
        public int CurrentRate { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
    }
}