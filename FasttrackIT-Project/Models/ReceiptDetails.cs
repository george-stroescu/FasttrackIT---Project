using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FasttrackIT_Project.Models
{
    public class ReceiptDetails
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("HeaderInfo")]
        public int HeaderInfoId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
