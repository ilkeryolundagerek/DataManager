using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IShoppingService
    {
        Task<IEnumerable<ShoppingItemDTO>> GetShoppingItems();
        Task<ShoppingCartDTO> GetShoppingCart();
        Task AddToCart(int pid, int qty = 1);
        Task RemoveFromCart(int pid, bool all = false);
    }
}
