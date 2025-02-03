using CoreEComMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreEComMVC.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartServices _services;

        public CartViewComponent(ICartServices services)
        {
            _services = services;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartItems = await _services.getCartItems();
            return View(cartItems);
        }
    }
}
