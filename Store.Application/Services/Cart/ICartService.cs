using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Cart
{
    public  interface ICartService
    {
        ResultDto AddToCart(long ProductId, Guid BroswerId);
        ResultDto RemoveFromCart(long ProductId, Guid BroswerId);
        ResultDto<CartDto> GetMyCart(Guid BroswerId,long? userid);
        ResultDto Add(long CartItemId);
        ResultDto LowOff(long CartItemId);

    }
           

}

