using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FasttrackIT_Project.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
    }
}
