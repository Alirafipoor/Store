using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.User.Queries.GetUser
{
    public interface IGetUserService
    {
        ResultGetUser Execute(RequestGetUser request);
    }
}
