using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;

namespace Store.Application.Services.User.Queries.GetRole
{
    public class GetRoleServices : IGetRoleServices
    {
        private readonly IDataBaseContext _context;
        public GetRoleServices(IDataBaseContext con)
        {
            _context = con;
        }
        public ResultDto<List<ResultRole>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new ResultRole
            {
                Id = p.Id,
                Name = p.Name,

            }).ToList();

            return new ResultDto<List<ResultRole>>()
            {
                Data = roles,
                IsSuccess = true,
                Message = ""
            };
        }
    }
}
