using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Queries.GetProductDetailsForSite
{
    public interface IGetProductDetailsForSite
    {
        ResultDto<ProductDetailForSiteDto> Execute(long Id);
    }
}
