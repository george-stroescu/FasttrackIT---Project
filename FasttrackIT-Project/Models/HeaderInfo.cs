using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FasttrackIT_Project.Models
{
    public class HeaderInfo
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 100)]
        public float Discount { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }
    }
}
