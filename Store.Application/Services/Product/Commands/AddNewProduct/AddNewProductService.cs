using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;
using Store.Domain.Entites.Products;

namespace Store.Application.Services.Product.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddNewProductService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }
        public ResultDto Execute(RequestAddNewProductDto Request)
        {
            var category = _context.Categories.Find(Request.CategoryId);

             Domain.Entites.Products.Product product = new Domain.Entites.Products.Product()
            {
                Brand = Request.Brand,
                Description = Request.Description,
                Name = Request.Name,
                Price = Request.Price,
                Inventory = Request.Inventory,
                Category = category,
                Displayed = Request.Displayed,
            };


            _context.Products.Add(product);

            List<ProductImages> productImages = new List<ProductImages>();
            foreach (var item in Request.Images)
            {
                var uploadedResult = UploadFile(item);
                productImages.Add(new ProductImages
                {
                    Product = product,
                    Src = uploadedResult.FileNameAddress,
                });
            }

            _context.ProductImages.AddRange(productImages);


            List<ProductFeatures> productFeatures = new List<ProductFeatures>();
            foreach (var item in Request.Features)
            {
                productFeatures.Add(new ProductFeatures
                {
                    DisplayName = item.DisplayName,
                    Value = item.Value,
                    Product = product,
                });
            }
            _context.ProductFeatures.AddRange(productFeatures);

            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
            };
        }

        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }
}

