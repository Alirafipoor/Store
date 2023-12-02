using Microsoft.AspNetCore.Http;
using Store.Domain.Entites.HomePages;

namespace Store.Application.Services.HomePages.AddHomePageImage
{
   
        public class requestAddHomePageImagesDto
        {
            public IFormFile file { get; set; }
            public string Link { get; set; }
            public ImageLocation ImageLocation { get; set; }
        }
    }

