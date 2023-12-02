using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;
using Store.Domain.Entites.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Finance.Commands.AddRequestPay
{
    public  interface IAddRequestPay
    {

        ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId);

    }
    public class AddRequestPay : IAddRequestPay
    {
        private readonly IDataBaseContext _context;
        public AddRequestPay(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int Amount, long UserId)
        {
            var user = _context.Users.Find(UserId);

            RequestPay request = new RequestPay()
            {
                Guid = Guid.NewGuid(),
                Amount = Amount,
                User = user,
                IsPay = false
            };

            _context.RequestPays.Add(request);
            _context.SaveChanges();

            return new ResultDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto
                {
                    Guid = request.Guid,
                },
                IsSuccess = true
            };
        }
    }
    public class ResultRequestPayDto
    {
        public Guid Guid { get; set; }
    }
}
