using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPMvcEva.Models
{
    public class Info
    { 
        [Required(ErrorMessage ="Champs obligatoire")]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        public string matricule { get; set; }
        [Required]
        public string fonction { get; set; }
        public string departement { get; set; }
        public string service { get; set; }
    }
}