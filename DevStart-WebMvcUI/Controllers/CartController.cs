using DevStart_DataAccsess.Contexts;
using DevStart_Service.Extensions;
using DevStart_WebMvcUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevStart_WebMvcUI.Controllers
{
    public class CartController : Controller
    {
        private readonly DevStartDbContext _context;

        public CartController(DevStartDbContext context)
        {
            _context = context;
        }

        List<CartItem> cart = new List<CartItem>(); //bu satır SEPET!!
        CartItem cartItem = new CartItem();           //bu satır SİPARİŞ!!

        public IActionResult Index()
        {
            cart = GetCart(); //session'dan sepeti alıyoruz.
            var totalQuantity = cartItem.TotalQuantity(cart);
            var totalPrice = cartItem.TotalPrice(cart);

            ViewBag.TotalQuantity = totalQuantity;
            ViewBag.TotalPrice = totalPrice > 0 ? totalPrice : 0;

            return View(cart);
        }

        public IActionResult Add(Guid CourseId, int Adet)
        {
            var course = _context.Courses.Find(CourseId);  // Kursu buluyoruz.

            if (course == null)
            {
                return NotFound();  // Eğer kurs bulunamazsa 404 döndür.
            }

            cart = GetCart();  // Session'dan sepeti alıyoruz.

            cartItem.CourseId = course.CourseId;  // Siparişi oluşturuyoruz.
            cartItem.CourseTitle = course.CourseTitle;
            cartItem.CourseQuantity = Adet;
            cartItem.CoursePrice = course.CoursePrice;

            cart = cartItem.AddToCart(cart, cartItem);  // Siparişi sepete ekliyoruz.

            SetCart(cart);  // Sepeti session'a kaydediyoruz.
            return RedirectToAction("Index");
        }

        public List<CartItem> GetCart()
        {
            return HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
        }

        public void SetCart(List<CartItem> cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}
