namespace DevStart_WebMvcUI.Models
{
    public class CartItem
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; }
        public int CourseQuantity { get; set; }
        public decimal CoursePrice { get; set; }

        public List<CartItem> AddToCart(List<CartItem> cart, CartItem cartItem)  //cart-->sepet  cartItem-->yeni sipariş
        {
            //if (cart.Any(c => c.MovieId == cartItem.MovieId)) //Any, bize sadece var mı yok mu sorgusunu yapıyor. sipariş sepette varsa true döner.
            //{
            //    //ürünü bulup adet arttırılacak
            //}
            var item = cart.Find(c => c.CourseId == cartItem.CourseId);  //sepette yeni siparişle aynı üründen varsa yakalar.
            if (item != null)
            {
                item.CourseQuantity += cartItem.CourseQuantity; //aynı ürünü bulup miktarını yeni siparişin miktarı kadar arttıyoruz
            }
            else
            {
                cart.Add(cartItem);  //siparişi sepete ekler.
            }
            return cart;
        }

        public List<CartItem> DeleteFromCart(List<CartItem> cart, Guid CourseId)
        {
            cart.RemoveAll(c => c.CourseId == CourseId);
            return cart;
        }

        public int TotalQuantity(List<CartItem> cart)
        {
            int total = cart.Sum(c => c.CourseQuantity);
            return total;
        }

        public decimal TotalPrice(List<CartItem> cart)
        {
            decimal total = cart.Sum(c => c.CourseQuantity * c.CoursePrice);
            return total;
        }

    }
}
