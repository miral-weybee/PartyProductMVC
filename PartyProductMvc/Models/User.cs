using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PartyProductMvc.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("User Name:")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}