using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMvc.Models
{
    public class AssignParty
    {
        [Key]
        [DisplayName("#")]
        public int AssignPartyId { get; set; }
        [DisplayName("Party Name")]
        [Required]
        public Party Party { get; set; }
        [DisplayName("Product Name")]
        [Required]
        public Product Product { get; set; }
    }
}