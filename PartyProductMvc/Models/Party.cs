using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PartyProductMvc.Models
{
    public class Party
    {
        [Key]
        public int PartyId { get; set; }

        [Required(ErrorMessage = "Party Name is required..")]
        [DisplayName("Party Name")]
        public string PartyName { get; set; }

    }
}