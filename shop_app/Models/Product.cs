using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop_app.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Name is required ...")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "min: 2, max: 20")]
        public string? Name { get; set; } = string.Empty;
        [Precision(10, 2)]
        [Required(ErrorMessage = "Price is required ...")]
        [Range(0.01, 100000.00, ErrorMessage = "min: 0.01, max: 100000.00")]
        public decimal Price { get; set; } = decimal.Zero;
        [Required(ErrorMessage = "Description is required ...")]
        [StringLength(1024, MinimumLength = 2, ErrorMessage = "min: 2, max: 1024")]
        public string? Description { get; set; } = string.Empty;
    }
}
