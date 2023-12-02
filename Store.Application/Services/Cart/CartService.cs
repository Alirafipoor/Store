using Microsoft.EntityFrameworkCore;
using Store.Application.interfaces.Contexts;
using Store.Common.Dtos;
using Store.Domain.Entites.Carts;
using Store.Domain.Entites.Users;

namespace Store.Application.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Add(long CartItemId)
        {

            var cartItem = _context.CartItems.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto AddToCart(long ProductId, Guid BroswerId)
        {
            var cart = _context.Carts.Where(x => x.BroswerId == BroswerId).FirstOrDefault();

            if (cart == null)
            {
                Store.Domain.Entites.Carts.Cart newcart = new Domain.Entites.Carts.Cart()
                {
                    BroswerId = BroswerId,
                    Finish = false
                };
                _context.Carts.Add(newcart);
                _context.SaveChanges();
                cart = newcart;

            }


            var product = _context.Products.Find(ProductId);

            var cartitem = _context.CartItems.Where(x => x.CartId == cart.Id && x.ProductId == product.Id).FirstOrDefault();

            if (cartitem != null)
            {
                cartitem.Count++;
            }

            CartItem cartItem = new CartItem()
            {
                Cart = cart,
                Price = product.Price,
                Count = 1,
                Product = product,
            };
            return new ResultDto
            {
                IsSuccess = true
            };


        }

        public ResultDto<CartDto> GetMyCart(Guid BroswerId,long? userid)
        {
            var cart = _context.Carts
                   .Include(x => x.CartItems)
                   .ThenInclude(x => x.Product)
                   .ThenInclude(x=>x.ProductImages)
                   .Where(x => x.BroswerId == BroswerId)
                  .OrderByDescending(p => p.Id)
                  .FirstOrDefault();
            if(userid != null)
            {
                var user = _context.Users.Find(userid);
                cart.User = user;
                _context.SaveChanges();
            }

            return new ResultDto<CartDto>
            {
                Data = new CartDto
                {
                    CartItems = cart.CartItems.Select(p => new CartItemDto
                    {

                        Price = p.Price,
                        Count = p.Count,
                        Product = p.Product.Name,
                        Images= p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
                        Id=p.Id

                    }).ToList(),
                }
                ,
                IsSuccess = true
            };
            


        }

        public ResultDto LowOff(long CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);

            if (cartItem.Count <= 1)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                };
            }
            cartItem.Count--;
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto RemoveFromCart(long ProductId, Guid BroswerId)
        {
            var cartitem = _context.CartItems.Where(x => x.ProductId == ProductId && x.Cart.BroswerId == BroswerId).FirstOrDefault();

            if (cartitem == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "we dont have this products"
                };
            }
            else
            {
                cartitem.IsRemoved = true;
                cartitem.RemoveTime=DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "done"
                };
            }
        }


    }
           

}

