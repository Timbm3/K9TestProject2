using K9TestProject3.Fantastic;
using System.Collections.Generic;

namespace K9TestProject3.HelpersLib
{
    public class ProductHelpers
    {
        public static ProductVM CreateViewModelFromProduct(Product product2, List<Color> colorList, List<Size> sizeList)
        {
            var model2 = new ProductVM(product2);
            if (product2 != null)
            {
                foreach (ColorAttribute colorAttribute in product2.ColorAttributes)
                {
                    ColorAttributeVM colorAttributeVm = new ColorAttributeVM()
                    {
                        ColorAttributeId = colorAttribute.ColorAttributeId,
                        ProductId = colorAttribute.ProductId,
                        ColorId = colorAttribute.ColorId,
                        SizeAttributes = new List<SizeAttributeVM>(),
                        Colors = colorList
                    };

                    foreach (SizeAttribute sizeAttribute in colorAttribute.SizeAttributes)
                    {
                        SizeAttributeVM sizeAttributeVm = new SizeAttributeVM()
                        {
                            SizeAttributeId = sizeAttribute.SizeAttributeId,
                            ColorAttributeId = sizeAttribute.ColorAttributeId,
                            SizeId = sizeAttribute.SizeId,
                            Quantity = sizeAttribute.SizeId,
                            Sizes = sizeList
                        };
                        colorAttributeVm.SizeAttributes.Add(sizeAttributeVm);
                    }
                    model2.ColorAttributes.Add(colorAttributeVm);
                }
            }
            return model2;
        }

        public static Product CreateProductFromViewModel(ProductVM model)
        {
            var product = new Product()
            {
                ProductId = model.ProductId,
                Productname = model.Productname,
                Category = model.Category,
            };
            int id = -1;
            foreach (ColorAttributeVM colorAttribute in model.ColorAttributes ?? new List<ColorAttributeVM>())
            {
                ColorAttribute colorDto = new ColorAttribute()
                {
                    ColorAttributeId = id,
                    ColorId = colorAttribute.ColorId,
                    ProductId = colorAttribute.ProductId,
                    SizeAttributes = new List<SizeAttribute>()
                };
                id--;
                int sizeId = -1;
                foreach (SizeAttributeVM sizeAttribute in colorAttribute.SizeAttributes ?? new List<SizeAttributeVM>())
                {
                    SizeAttribute sizeDto = new SizeAttribute()
                    {
                        SizeId = sizeAttribute.SizeId,
                        SizeAttributeId = sizeId,
                        Quantity = sizeAttribute.Quantity,
                        ColorAttributeId = sizeAttribute.ColorAttributeId,
                    };
                    colorDto.SizeAttributes.Add(sizeDto);
                    sizeId--;

                }
                product.ColorAttributes.Add(colorDto);
            }
            return product;
        }

        public static Product EditProductFromViewModel(ProductVM model)
        {
            var product = new Product()
            {
                ProductId = model.ProductId,
                Productname = model.Productname,
                Category = model.Category,
            };
            var id = -1;
            foreach (ColorAttributeVM colorAttribute in model.ColorAttributes ?? new List<ColorAttributeVM>())
            {
                var colorDto = new ColorAttribute();
                colorDto.ColorId = colorAttribute.ColorId;
                colorDto.ProductId = model.ProductId;
                colorDto.SizeAttributes = new List<SizeAttribute>();

                if (colorAttribute.ColorAttributeId == 0)
                {
                    colorDto.ColorAttributeId = id;
                    id--;
                }
                else
                {
                    colorDto.ColorAttributeId = colorAttribute.ColorAttributeId;
                }

                var sizeId = -1;
                foreach (SizeAttributeVM sizeAttribute in colorAttribute.SizeAttributes ?? new List<SizeAttributeVM>())
                {
                    var sizeDto = new SizeAttribute();
                    sizeDto.SizeId = sizeAttribute.SizeId;
                    sizeDto.Quantity = sizeAttribute.Quantity;
                    sizeDto.ColorAttributeId = colorDto.ColorAttributeId;

                    if (sizeAttribute.SizeAttributeId == 0)
                    {
                        sizeDto.SizeAttributeId = sizeId;
                        sizeId--;
                    }
                    else
                    {
                        sizeDto.SizeAttributeId = sizeAttribute.SizeAttributeId;
                    }

                    colorDto.SizeAttributes.Add(sizeDto);
                }
                product.ColorAttributes.Add(colorDto);
            }
            return product;
        }
    }
}