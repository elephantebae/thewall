using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace thewall.Models
{

    public class Login
    {
        [Required]
        [EmailAddress]
        public string LogEmail {get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string LogPassword { get; set; }
    }
}