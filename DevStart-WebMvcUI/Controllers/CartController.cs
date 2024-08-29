using DevStart_DataAccsess.Contexts;
using DevStart_Entity.Entities;
using DevStart_Entity.Interfaces;
using DevStart_Service.Extensions;
using DevStart_WebMvcUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Course> _courseRepo;
        

        public CartController(IRepository<Course> courseRepo)
        {
            _courseRepo = courseRepo;
        }
        List<CartItem> cart = new List<CartItem>(); //bu satır SEPET!!
        CartItem cartItem = new CartItem();
        public IActionResult Index()
        {
            //var cart = GetCart(); // Session'dan sepeti alıyoruz.

            //// Sepetteki toplam adet ve toplam tutarı hesaplayın
            //var totalQuantity = cart.Sum(item => item.CourseQuantity);
            //var totalPrice = cart.Sum(item => item.CourseQuantity * item.CoursePrice);

            //// TempData'ya hesaplamaları atayın
            //TempData["ToplamAdet"] = totalQuantity;
            //TempData["TotalTutar"] = totalPrice;

            //return View(cart);

            var cart = GetCart(); // Session'dan sepeti alıyoruz.
            TempData["ToplamAdet"] = cartItem.TotalQuantity(cart);
            if (cartItem.TotalPrice(cart) > 0)
                TempData["ToplamTutar"] = cartItem.TotalPrice(cart);
            return View(cart);
        }

        public async Task<IActionResult> Add(Guid CourseId, int adet)
        {
            var course = await _courseRepo.GetByIdAsync(CourseId); // Sipariş edilecek ürünü buluyorum burada.

            var cart = GetCart(); // Sepetimi alıyorum

            var cartItem = new CartItem
            {
                CourseId = course.CourseId,
                CourseTitle = course.CourseTitle,
                CourseQuantity = adet,
                CoursePrice = course.CoursePrice
            };

            cart = CartItem.AddToCart(cart, cartItem); // Yeni siparişi sepete ekliyoruz.

            SetCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid courseId)
        {
            var cart = GetCart();
            cart = CartItem.DeleteFromCart(cart, courseId);
            SetCart(cart); // Session'a sepetin son halini kayıt ediyoruz.
            return RedirectToAction("Index");
        }

        public void SetCart(List<CartItem> sepet)
        {
            HttpContext.Session.SetJson("sepet", sepet); // Alışveriş sepetimizi session'a kayıt ediyoruz.
        }

        public List<CartItem> GetCart()
        {
            return HttpContext.Session.GetJson<List<CartItem>>("sepet") ?? new List<CartItem>();
        }

        public IActionResult DeleteCart()
        {
            HttpContext.Session.Remove("sepet"); // Sepeti boşalt
            return RedirectToAction("Index");
        }
    }
}