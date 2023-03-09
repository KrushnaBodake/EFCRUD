using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public String? Pname { get; set; }
        [Required]
        public String? Company { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
