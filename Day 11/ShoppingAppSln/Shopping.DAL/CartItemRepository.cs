using Shopping.Model;
using Shopping.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override CartItem Delete(int key)
        {
            CartItem cartItem= GetByKey(key);
            if(cartItem != null)
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }

        public override CartItem GetByKey(int key)
        {
            CartItem cartItem= items.FirstOrDefault(c=>c.ProductId==key);
            if (cartItem != null)
            {
                return cartItem;
            }
            throw new NoCartItemFoundExeption();
        }

        public override CartItem Update(CartItem item)
        {
            CartItem cartItem = GetByKey(item.ProductId);
            if (cartItem != null)
            {
                cartItem = item;
            }
            return cartItem;
        }
    }
}
