using System.Collections.Generic;

namespace K9TestProject3.Fantastic
{
    public class ProductVM
    {
        public ProductVM()
        {

        }

        public ProductVM(Product product)
        {
            ProductId = product.ProductId;
            Productname = product.Productname;
            Category = product.Category;

            ColorAttributes = new List<ColorAttributeVM>();
        }

        public int ProductId { get; set; }
        public string Productname { get; set; }
        public string Category { get; set; }
        public List<ColorAttributeVM> ColorAttributes { get; set; }




        public int ColorId { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public string ColorName { get; set; }



        public int SizeId { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public string SizeName { get; set; }

    }

    public class ColorAttributeVM
    {
        public ColorAttributeVM()
        {

        }

        public ColorAttributeVM(ColorAttribute row)
        {
            ColorAttributeId = row.ColorAttributeId;
            ProductId = row.ProductId;
            // SizeAttributeId = row.SizeAttributeId;
            ColorId = row.ColorId;
            SizeAttributes = new List<SizeAttributeVM>();
        }

        public int ColorAttributeId { get; set; }

        public int ProductId { get; set; }

        // public int SizeAttributeId { get; set; }
        public List<SizeAttributeVM> SizeAttributes { get; set; }

        public int ColorId { get; set; }
    }

    public class SizeAttributeVM
    {
        public SizeAttributeVM()
        {

        }

        public SizeAttributeVM(SizeAttribute row)
        {
            SizeAttributeId = row.SizeAttributeId;
            SizeId = row.SizeId;
            Quantity = row.Quantity;
            ColorAttributeId = row.ColorAttributeId;
        }
        public int SizeAttributeId { get; set; }

        public int ColorAttributeId { get; set; }
        public int SizeId { get; set; }

        public int Quantity { get; set; }
    }
    public class ColorVM
    {
        public ColorVM()
        {

        }

        public ColorVM(Color row)
        {
            ColorId = row.ColorId;
            ColorName = row.ColorName;
        }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }

    public class SizeVM
    {
        public SizeVM()
        {

        }

        public SizeVM(Size row)
        {
            SizeId = row.SizeId;
            SizeName = row.SizeName;
        }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
    }
}