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

        public int PartyId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [DisplayName("Current Rate")]
        public int CurrentRate { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        public Party Party { get; set; }

        public Product Product { get; set; }
    }
}