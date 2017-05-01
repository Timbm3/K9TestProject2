using K9TestProject2.Models.ProductModels;
using System.Collections.Generic;

namespace K9TestProject2.ViewModels
{
    public class ProductVM
    {
        public ProductVM()
        {
            Egenskaps = new List<EgenskapVM>();
        }

        public ProductVM(Product row)
        {
            ProductId = row.ProductId;
            Productname = row.Productname;
            Category = row.Category;
            Egenskaps = new List<EgenskapVM>();
        }


        public int ProductId { get; set; }
        public string Productname { get; set; }
        public string Category { get; set; }
        public List<EgenskapVM> Egenskaps { get; set; }
    }

    public class EgenskapVM
    {
        public int EgenskapId { get; set; }

        // Product Id
        public int ProductId { get; set; }

        // Color Id
        public int ColorId { get; set; }
        public string ColorName { get; set; }

        // Size Id
        public int SizeId { get; set; }
        public string SizeName { get; set; }

        // Quantity
        public int Quantity { get; set; }
    }
}