using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FasttrackIT_Project.Models
{
    public class OfferDetail
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("OfferHeaderId")]
        public OfferHeader OfferHeader { get; set; }
    }
}
