using Store.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Commands.RegisterUser
{
    public interface  IRegisterUserService
    {
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
            
    }
}
