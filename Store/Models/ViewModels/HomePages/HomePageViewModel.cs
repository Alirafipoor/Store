using Store.Application.Services.Common.Queries.GetHomePageImage;
using Store.Application.Services.Common.Queries.GetSlider;
using Store.Application.Services.Product.Queries.GetProductForSite;

namespace Store.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImagesDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }
    }
}
