using Microsoft.EntityFrameworkCore;
using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;
using Store.Domain.Entites.Products;

namespace Store.Application.Services.Product.Queries.GetProductDetailsForAdmin
{
    public class GetProductDeatailsForAdmin : IgetProductDetailsForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetProductDeatailsForAdmin(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailForAdmindto> Execute(long Id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .Where(p => p.Id == Id)
                .FirstOrDefault();

            return new ResultDto<ProductDetailForAdmindto>()
            {
                IsSuccess = true,
                Message = "",
                Data = new ProductDetailForAdmindto()
                {
                    Brand = product.Brand,
                    Category = GetCategory(product.Category),
                    Description = product.Description,
                    Displayed = product.Displayed,
                    Id = product.Id,
                    Inventory = product.Inventory,
                    Name = product.Name,
                    Price = product.Price,
                    Features = product.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value
                    }).ToList(),
                    Images = product.ProductImages.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id = p.Id,
                        Src = p.Src,
                    }).ToList(),
                }
            };
        }
        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }
}
