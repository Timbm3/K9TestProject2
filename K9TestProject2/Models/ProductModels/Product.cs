using System.Collections.Generic;

namespace K9TestProject2.Models.ProductModels
{
    public class Product
    {
        public Product()
        {
            Egenskaps = new List<Egenskap>();
        }
        public int ProductId { get; set; }
        public string Productname { get; set; }
        public string Category { get; set; }
        public List<Egenskap> Egenskaps { get; set; }
    }
}