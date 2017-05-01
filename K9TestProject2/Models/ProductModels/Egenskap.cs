using System.ComponentModel.DataAnnotations;

namespace K9TestProject2.Models.ProductModels
{
    public class Egenskap
    {
        [Key]
        public int EgenskapId { get; set; }

        // Product Id
        public int ProductId { get; set; }

        // Color Id
        public int ColorId { get; set; }
        public Color Color { get; set; }

        // Size Id
        public int SizeId { get; set; }
        public Size Size { get; set; }

        // Quantity
        public int Quantity { get; set; }
    }
}