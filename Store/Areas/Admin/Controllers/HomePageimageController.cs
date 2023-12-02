using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.HomePages.AddHomePageImage;
using static Store.Application.Services.HomePages.AddHomePageImage.IAddHomePageImage;
using Store.Domain.Entites.HomePages;


namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageimageController : Controller
    {
        private readonly IAddHomePageImage _addhomepageimage;
        public HomePageimageController(IAddHomePageImage addhomepageimage)
        {
            _addhomepageimage = addhomepageimage;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file, string link, ImageLocation imageLocation)
        {
            _addhomepageimage.Execute(new requestAddHomePageImagesDto
            {
                file = file,
                Link = link,
                ImageLocation = imageLocation,
            });


            return View();
        }

    }
}
