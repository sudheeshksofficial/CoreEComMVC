using CoreEComMVC.Models;
using CoreEComMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CoreEComMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly IStockService _stockService;
        private readonly ICartServices _cartServices;
        public ItemController(IStockService stockService,ICartServices cartServices)
        {

            _stockService = stockService;
            _cartServices = cartServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Purchase")]//url pattern
        public async Task<IActionResult> Showing()
        {
            var items = await _stockService.GetStockAsync();
            return View(items);
        }

        [HttpGet]//url pattern 
        public IActionResult Addingstock()//action method name which called from view
        {
            return View();//view name if we use different viewname from actionmethod name
        }

        [HttpPost]
        public async Task<IActionResult> Addingstock(ItemModel item)
        {
            if (ModelState.IsValid)
            {
                var addeditem = await _stockService.AddStocking(item);
                return RedirectToAction("Showing"); // Change "showing" to the name of the action you want to redirect to.
            }
            return View("Addingstock", item);
        }



        //adding to cart
        [HttpPost]
        public IActionResult AddCarts(int id, string name, decimal price, int stock, int quantity)
        {
            var cartItem = new CartModel
            {
                ItemId = id,
                Name = name,
                Price = price,
                Quantity = quantity
            };
            var message = _cartServices.InsertCart(cartItem,stock);

            return Json(new { success = message == "Item added to cart successfully." || message =="more item added successfully", message });
        }

        //items in cart
        [HttpGet]
        public IActionResult GettingCart()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var success = _cartServices.RemoveCart(id);

            if (success)
            {
                return Json(new { success = true, message = "Item removed from cart successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Item not found in cart." });
            }
        }
        public IActionResult GoToPayment(decimal totalAmount)
        {
            // Pass the totalAmount to the payment view
            return View("Payment", totalAmount);
        }


    }
}
