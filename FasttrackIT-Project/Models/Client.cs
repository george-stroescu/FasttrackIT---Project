using System.ComponentModel.DataAnnotations;

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
