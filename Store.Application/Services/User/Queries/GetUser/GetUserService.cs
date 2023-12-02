using Store.Application.interfaces.Contexts;
using Store.Common;

namespace Store.Application.Services.User.Queries.GetUser
{
    public class GetUserService : IGetUserService
    {
        private readonly IDataBaseContext context;
        public GetUserService(IDataBaseContext con)
        {
            context = con;
        }
        public ResultGetUser Execute(RequestGetUser request)
        {
            var user = context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                user = context.Users.Where(x => x.FullName.Contains(request.SearchKey) && x.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;

            var UserList = user.ToPage(request.page, 20, out rowsCount).Select(x => new GetUserDto
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                IsActive = x.IsActive
            }).ToList();

            return new ResultGetUser
            {
                Users = UserList,
                Rows = rowsCount,
            };
        }
    }
}
