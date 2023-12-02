using Microsoft.AspNetCore.Hosting;
using Store.Application.interfaces.Contexts;
using Store.Application.interfaces.FacadPattern;
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

namespace Store.Application.Services.Product.FacadPattern
{
    public class ProductFacad:IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment enviroment)
        {
            _context = context;
            _environment = enviroment;
        }
        private IAddNewCategoryService _AddNewcategoryService;

        public IAddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _AddNewcategoryService=_AddNewcategoryService ?? new AddNewCategoryService(_context);
            }
        }

        private IGetCategoryService _GetCategoryService;

        public IGetCategoryService GetCategoryService
        {

            get
            {
                return _GetCategoryService = _GetCategoryService ?? new GetCategoryService(_context);
            }
        }

        private IAddNewProductService _addnewproductservice;

        public IAddNewProductService AddNewProductService
        {
            get
            {
                return _addnewproductservice=_addnewproductservice ?? new AddNewProductService(_context,_environment);
            }
        }

        private IGetAllCategory _GetAllCategory;

        public IGetAllCategory GetAllCategory
        {
            get
            {
                return _GetAllCategory=_GetAllCategory ?? new GetAllCategory(_context);
            }
        }

        private IGetProductForAdminService _GetProductForAdminService;

        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _GetProductForAdminService = _GetProductForAdminService ?? new GetProductAdminService(_context);
            }
        }

        private IgetProductDetailsForAdmin _GetProductdetailsForAdmin;
        public IgetProductDetailsForAdmin GetProductDetailsForAdmin
        {
            get
            {
                return _GetProductdetailsForAdmin=_GetProductdetailsForAdmin ?? new GetProductDeatailsForAdmin(_context);
            }
        }

        private IDeleteProduct _DeleteProduct;

        public IDeleteProduct deleteProduct
        {
            get
            {
                return _DeleteProduct=_DeleteProduct ?? new DeleteProduct(_context);
            }
        }

        private  IGetProductForSite _GetProductForSite;

        public IGetProductForSite GetProductForSite
        {
            get
            {
                return _GetProductForSite=_GetProductForSite ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailsForSite _GetProductDetailsForSite;
        
        public IGetProductDetailsForSite GetProductDetailsForSite
        {
            get
            {
                return _GetProductDetailsForSite =_GetProductDetailsForSite ?? new GetProductDetailForSiteService(_context);
            }
        }

       
    }
}
