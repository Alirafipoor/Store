using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;

namespace Store.Application.Services.Product.Commands.DeleteProduct
{
    public class DeleteProduct : IDeleteProduct
    {
        private readonly IDataBaseContext _context;
        public DeleteProduct(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            var product=_context.Products.Where(x=>x.Id == Id).FirstOrDefault();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "محصول با موفقیت حذف شد"
            };
        }
    }
}
