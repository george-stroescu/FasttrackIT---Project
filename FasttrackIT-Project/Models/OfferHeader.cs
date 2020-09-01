using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FasttrackIT_Project.Models
{
    public class OfferHeader
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 100)]
        public float Discount { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public List<OfferDetail> Details { get; set; } = new List<OfferDetail>();
    }
}
