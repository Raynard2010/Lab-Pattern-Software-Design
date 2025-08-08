using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectLab.Models;

namespace ProjectLab.Handlers
{
    public class CartHandler
    {
        public static List<CartItem> GetCart()
        {
            if (HttpContext.Current.Session["cart"] == null)
            {
                HttpContext.Current.Session["cart"] = new List<CartItem>();
            }

            return (List<CartItem>)HttpContext.Current.Session["cart"];
        }

        public static void AddToCart(Card card, int quantity)
        {
            var cart = GetCart();
            var existingItem = cart.FirstOrDefault(c => c.Card.CardId == card.CardId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    Card = card,
                    Quantity = quantity
                });
            }

            HttpContext.Current.Session["cart"] = cart;
        }

        public static void RemoveFromCart(int cardId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.Card.CardId == cardId);
            if (item != null)
            {
                cart.Remove(item);
            }
            HttpContext.Current.Session["cart"] = cart;
        }

        public static void UpdateCartQuantity(int cardId, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.Card.CardId == cardId);
            if (item != null)
            {
                item.Quantity = quantity;
            }
            HttpContext.Current.Session["cart"] = cart;
        }

        public static void ClearCart()
        {
            HttpContext.Current.Session["cart"] = new List<CartItem>();
        }
    }
}
