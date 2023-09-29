using Core.Abstracts.IServices;
using Core.Abstracts.IUnitOfWorks;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BusinessLogic.Services
{
    public class ShoppingService : IShoppingService
    {
        private IUnitOfWork uow;
        private string uid;

        public ShoppingService(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor)
        {
            this.uow = uow;
            this.uid = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public Task AddToCart(int pid, int qty = 1)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoppingCartDTO> GetShoppingCart()
        {
            var carts = await uow.ShoppingCartRepo.GetManyAsync(x => x.UserId.Equals(uid));
            var cart = carts.OrderByDescending(x => x.CDate).FirstOrDefault();
            var items = await uow.ShoppingCartItemRepo.GetManyAsync(x => x.ShoppingCartId.Equals(cart.Id), new string[] { "Product" });
            return new ShoppingCartDTO
            {
                Id = cart.Id,
                ProductCount = items.Count(),
                TotalDue = items.Sum(x => x.Quantity * x.Product.ListPrice)
            };
        }

        public Task<IEnumerable<ShoppingItemDTO>> GetShoppingItems()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCart(int pid, bool all = false)
        {
            throw new NotImplementedException();
        }
    }
}
