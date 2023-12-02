using Store.Application.Services.Product.Commands.AddNewCategoryService;
using Store.Application.Services.Product.Commands.AddNewProduct;
using Store.Application.Services.Product.Commands.DeleteProduct;
using Store.Application.Services.Product.Queries.GetAllCategory;
using Store.Application.Services.Product.Queries.GetCategoryService;
using Store.Application.Services.Product.Queries.GetProductDetailsForAdmin;
using Store.Application.Services.Product.Queries.GetProductDetailsForSite;
using Store.Application.Services.Product.Queries.GetProductForAdmin;
using Store.Application.Services.Product.Queries.GetProductForSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.interfaces.FacadPattern
{
    public interface IProductFacad
    {
        IAddNewCategoryService AddNewCategoryService { get;  }
        IGetCategoryService GetCategoryService {  get; }
        IAddNewProductService AddNewProductService { get; }
        IGetAllCategory GetAllCategory { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IgetProductDetailsForAdmin GetProductDetailsForAdmin { get; }
        IDeleteProduct deleteProduct { get; }
        IGetProductForSite GetProductForSite { get; }

        IGetProductDetailsForSite GetProductDetailsForSite { get; } 
    }
}
