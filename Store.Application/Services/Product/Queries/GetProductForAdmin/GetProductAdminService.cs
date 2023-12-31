﻿using Microsoft.EntityFrameworkCore;
using Store.Application.interfaces.Contexts;
using Store.Common;
using Store.Common.Dtos;

namespace Store.Application.Services.Product.Queries.GetProductForAdmin
{
    public class GetProductAdminService : IGetProductForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductForAdminDto> Execute(int Page=1,int PageSize=20)
        {
            int rowCount = 0;
            var products = _context.Products
                .Include(p => p.Category)
                .ToPage(Page, PageSize, out rowCount)
                .Select(p => new ProductsFormAdminList_Dto
                {
                    Id = p.CategoryId,
                    Brand = p.Brand,
                    Category = p.Category.Name,
                    Description = p.Description,
                    Displayed = p.Displayed,
                    Inventory = p.Inventory,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new ResultDto<ProductForAdminDto>()
            {
                Data = new ProductForAdminDto()
                {
                    Products = products,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }
}
