using Microsoft.EntityFrameworkCore;
using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Queries.GetCategoryService
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoryDto>> Execute(long? ParentId);

    }
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _context;
        private IDataBaseContext context;

        public GetCategoryService(IDataBaseContext context)
        {
            this.context = context;
        }

        public ResultDto<List<CategoryDto>> Execute(long? ParentId)
        {
            var categories = _context.Categories.Include(c => c.ParentCategory).Include(c => c.SubCategories)
                 .Where(c => c.ParentCategoryId == ParentId).ToList()
                 .Select(c => new CategoryDto()
                 {
                     Id = c.Id,
                     Name = c.Name,

                     Parent = c.ParentCategory != null ? new
                     ParentCategoryDto
                     {
                         Id = c.Id,
                         Name = c.Name,

                     }:null,
                     HasChild=c.SubCategories.Count()>0 ?true : false



                 }).ToList();
            return new ResultDto<List<CategoryDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };
        }
    }


    public class CategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }
    }
    public class ParentCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
