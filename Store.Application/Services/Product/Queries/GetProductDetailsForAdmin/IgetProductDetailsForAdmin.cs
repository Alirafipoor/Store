using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Queries.GetProductDetailsForAdmin
{
    public  interface IgetProductDetailsForAdmin
    {
        ResultDto<ProductDetailForAdmindto> Execute(long Id);
        
    }
}
