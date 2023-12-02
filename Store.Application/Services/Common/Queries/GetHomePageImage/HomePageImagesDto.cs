using Store.Domain.Entites.HomePages;

namespace Store.Application.Services.Common.Queries.GetHomePageImage
{
    public class HomePageImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
