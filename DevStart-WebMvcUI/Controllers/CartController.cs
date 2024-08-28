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
        CartItem cartItem = new CartItem();           //bu satır SİPARİŞ!!

        public IActionResult Index()
        {
            cart = GetCart(); // Session'dan sepeti alıyoruz.
            TempData["ToplamAdet"] = cartItem.TotalQuantity(cart);
            if (cartItem.TotalPrice(cart) > 0)
                TempData["ToplamTutar"] = cartItem.TotalPrice(cart);
            return View(cart);
        }

        public async Task<IActionResult> Add(Guid courseId, int adet)
        {
            var course = await _courseRepo.GetByIdAsync(courseId); // Sipariş edilecek ürünü buluyorum burada.

            cart = GetCart(); // Sepetimi istiyorum (ilk olarak boş sepet geliyor bize, aşağıda yazmıştık bu methodu)

            cartItem.CourseId = course.CourseId;  // Sipariş oluşturuyoruz burada.
            cartItem.CourseTitle = course.CourseTitle;
            cartItem.CourseQuantity = adet;
            cartItem.CoursePrice = course.CoursePrice;

            cart = cartItem.AddToCart(cart, cartItem); // Yeni siparişi sepete ekliyoruz.

            SetCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid courseId)
        {
            cart = GetCart();
            cart = cartItem.DeleteFromCart(cart, courseId);
            SetCart(cart); // Session'a sepetin son halini kayıt ediyoruz.
            return RedirectToAction("Index");
        }

        public void SetCart(List<CartItem> sepet)
        {
            HttpContext.Session.SetJson("sepet", sepet); // Alışveriş sepetimizi sepet isimli (key) session'a kayıt ediyoruz.
        }

        public List<CartItem> GetCart()
        {
            var sepet = HttpContext.Session.GetJson<List<CartItem>>("sepet") ?? new List<CartItem>(); // ?? işaretinin solu null olursa sağındaki kod devreye giriyor.
            return sepet;
        }

        public IActionResult DeleteCart()
        {
            HttpContext.Session.Remove("sepet"); // Sadece adı sepet olan session'ı siler.
            return RedirectToAction("Index");
        }




    }
}
