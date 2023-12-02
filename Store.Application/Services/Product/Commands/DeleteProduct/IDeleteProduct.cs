using Microsoft.EntityFrameworkCore.Storage;
using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Product.Commands.DeleteProduct
{
    public  interface IDeleteProduct
    {
        ResultDto Execute(long Id);
    }
}
