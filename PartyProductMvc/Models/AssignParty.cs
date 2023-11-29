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

        public int PartyId { get; set; }

        public int ProductId { get; set; }

        [DisplayName("Party Name")]
        
        public Party Party { get; set; }
        [DisplayName("Product Name")]
        
        public Product Product { get; set; }
    }
}