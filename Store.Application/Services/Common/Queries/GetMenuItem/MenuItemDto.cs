namespace Store.Application.Services.Common.Queries.GetMenuItem
{
    public class MenuItemDto
    {
        public long CatId { get; set; }
        public string name { get; set; }
        public List<MenuItemDto> Child { get; set; }
    }
}
