using CoreEComMVC.Models;

namespace CoreEComMVC.Services
{
    public interface ICartServices
    {
        public Task<IEnumerable<CartModel>> getCartItems();

        public string InsertCart(CartModel item,int stock);

        public bool RemoveCart(int id);
    }
}
