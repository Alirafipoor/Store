using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Common.Queries.GetHomePageImage
{
    public interface IGetHomePageImage
    {
        ResultDto<List<HomePageImagesDto>> Execute();
    }
}
