using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K9TestProject3.Fantastic
{
    public class Product
    {
        public Product()
        {
            ColorAttributes = new List<ColorAttribute>();
        }

        [Key]
        public int ProductId { get; set; }
        public string Productname { get; set; }
        public string Category { get; set; }

        public List<ColorAttribute> ColorAttributes { get; set; }
    }

    public class ColorAttribute
    {
        public ColorAttribute()
        {
            SizeAttributes = new List<SizeAttribute>();
        }

        [Key]
        [Column(Order = 0)]
        public int ColorAttributeId { get; set; }

        [Column(Order = 1)]
        public int ProductId { get; set; }

        // public int SizeAttributeId { get; set; }
        public List<SizeAttribute> SizeAttributes { get; set; }

        [Column(Order = 2)]
        public int ColorId { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }
    }


    public class SizeAttribute
    {
        public SizeAttribute()
        {

        }

        public SizeAttribute(SizeAttributeVM model)
        {
            SizeAttributeId = model.SizeAttributeId;
            SizeId = model.SizeId;
            Quantity = model.Quantity;
        }
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeAttributeId { get; set; }

        //[Column(Order = 1)]
        public int ColorAttributeId { get; set; }
        [ForeignKey("ColorAttributeId")]
        public ColorAttribute ColorAttribute { get; set; }
        //public List<ColorAttribute> ColorAttributes { get; set; }

        [Column(Order = 1)]
        public int SizeId { get; set; }

        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }

        [Column(Order = 2)]
        public int Quantity { get; set; }
    }

    public class Color
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }

    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeName { get; set; }
    }

}