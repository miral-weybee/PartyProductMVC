using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartyProductMvc.Models
{
    public class ProductRate
    {
        public int Id { get; set; }
        [DisplayName("Product Name")]
        [Required]
        public Product ProductName { get; set; }
        [Required]
        [DisplayName("Rate")]
        public int Rate { get; set; }
        [DisplayName("Date Of Rate")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOfRate { get; set; }
    }
}