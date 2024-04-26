using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BL
{
    public interface ICartServices
    {
        Cart CreateCart(int customerId);
        Cart AddCartItem(int cartId, int productId, int quantity);
        Cart RemoveCartItem(int cartId, int productId);
        double CalculateTotalAmountAfterDiscountAndShippingCharge(Cart cart);
        double CalculateCartProductAmount(Cart cart);
    }
}
