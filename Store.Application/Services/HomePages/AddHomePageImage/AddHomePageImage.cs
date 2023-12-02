﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Store.Application.interfaces.Contexts;
using Store.Application.Services.Product.Commands.AddNewProduct;
using Store.Common.Dtos;
using Store.Domain.Entites.HomePages;

namespace Store.Application.Services.HomePages.AddHomePageImage
{
    
        public class AddHomePageImage : IAddHomePageImage
        {
            private readonly IDataBaseContext _context;
            private readonly IHostingEnvironment _environment;

            public AddHomePageImage(IDataBaseContext context, IHostingEnvironment hosting)
            {
                _context = context;
                _environment = hosting;
            }
            public ResultDto Execute(requestAddHomePageImagesDto request)
            {

                var resultUpload = UploadFile(request.file);

                HomePageImage homePageImages = new HomePageImage()
                {
                    link = request.Link,
                    Src = resultUpload.FileNameAddress,
                    ImageLocation = request.ImageLocation,
                };
                _context.HomePageImages.Add(homePageImages);
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                };
            }




            private UploadDto UploadFile(IFormFile file)
            {
                if (file != null)
                {
                    string folder = $@"images\HomePages\Slider\";
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

