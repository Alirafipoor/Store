using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.HomePages.AddHomePageImage
{
   
        public interface IAddHomePageImage
        {
            ResultDto Execute(requestAddHomePageImagesDto request);
        }
    
}
