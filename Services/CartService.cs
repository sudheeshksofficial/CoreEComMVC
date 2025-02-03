using CoreEComMVC.Data;
using CoreEComMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEComMVC.Services
{
    public class CartService : ICartServices
    {
        private readonly EcommerceDbContext _context;
        public CartService(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CartModel>> getCartItems()
        {
            var items = await _context.Cart.ToListAsync();
            return items;
        }

        public string InsertCart(CartModel item, int stock)
        {
            var existing = _context.Cart.FirstOrDefault(c => c.ItemId == item.ItemId);
            if (existing != null) 
            {
                if (item.Quantity + existing.Quantity > stock)
                {
                    return "not enough cart item available";
                }
                else
                {
                    
                    existing.Quantity += item.Quantity;
                    _context.SaveChanges();
                    return "more item added successfully";
                }
            }
            else
            {
                if (item.Quantity > stock)
                {
                    return "Not enough stock available.";
                }
                
                _context.Add(item);
                _context.SaveChanges();
               


            }

            return "Item added to cart successfully.";

        }

        public bool RemoveCart(int id)
        {
            var item = _context.Cart.FirstOrDefault(c =>c.CartId == id);

            if (item != null) { 
            _context.Cart.Remove(item);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
