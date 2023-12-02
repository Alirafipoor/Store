using Microsoft.EntityFrameworkCore;
using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;

namespace Store.Application.Services.Product.Queries.GetAllCategory
{
    public class GetAllCategory : IGetAllCategory
    {
        private readonly IDataBaseContext _context;
        public GetAllCategory(IDataBaseContext  context)
        {
            _context = context;
        }
        public ResultDto<List<AllCategoriesDto>> Execute()
        {
           var categories=_context
                .Categories
                .Include(p=>p.ParentCategory)
                .Where(p=>p.ParentCategoryId !=null)
                .ToList()
                .Select(p=>new AllCategoriesDto
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory.Name} - {p.Name}",
                }).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Message = "",
                IsSuccess = true,
                Data = categories
            };
        }
    }
}
