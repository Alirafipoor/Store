using Microsoft.EntityFrameworkCore;
using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;

namespace Store.Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuItem : IGetMenusItem
    {
        private readonly IDataBaseContext _context;
        public GetMenuItem(IDataBaseContext contetx)
        {
            _context = contetx;
        }
        public ResultDto<List<MenuItemDto>> Execute()
        {
            var category = _context.Categories
                .Include(p => p.SubCategories)
                .ToList()
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    name = p.Name,
                    Child = p.SubCategories.ToList().Select(x => new MenuItemDto
                    {
                        CatId = x.Id,
                        name = x.Name,

                    }).ToList()


                }).ToList();

            return new ResultDto<List<MenuItemDto>>()
            {
                IsSuccess = true,
                Data = category
            };
        }
    }
}
