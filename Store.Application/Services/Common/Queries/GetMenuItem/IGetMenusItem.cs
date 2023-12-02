using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenusItem
    {
        ResultDto<List<MenuItemDto>> Execute();
    }
}
