using Shopping.DAL;
using Shopping.Model;
using Shopping.Model.Exceptions;

namespace Shopping.BL
{
    public class CartBL : ICartServices
    {
        private readonly IRepository<int, Cart> _cartRepository;
        private readonly IRepository<int, Product> _productRepository;
        public CartBL(IRepository<int, Cart> cartRepository, IRepository<int, Product> productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public async Task<Cart> CreateCart(int customerId)
        {
            var existingCartForCustomer = (await _cartRepository.GetAll())
                .FirstOrDefault(c => c.CustomerId == customerId);
            if (existingCartForCustomer != null)
            {
                throw new CartAlreadyExistsForTheGivenCustomer();
            }
            Cart cart = new Cart
            {
                CustomerId = customerId,
                CartItems = new List<CartItem>()
            };
            return await _cartRepository.Add(cart);
        }

        public async Task<Cart> GetCartByCustomerID(int customerId)
        {
            var cartByCustomerId = (await _cartRepository.GetAll()).FirstOrDefault(c => c.CustomerId == customerId);
            if (cartByCustomerId != null)
            {
                return cartByCustomerId;
            }
            throw new NoCartFoundForTheCustomerIdGivenException();
        }

        public async Task<Cart> AddCartItem(int cartId, int productId, int quantity)
        {
            Cart cart = await _cartRepository.GetByKey(cartId);

            Product product = await _productRepository.GetByKey(productId);

            //Maximum 5 product per cart
            if (quantity > 5)
            {
                throw new MaxQuantityExceededException();
            }

            CartItem existingCartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
                CartItem cartItem = new CartItem
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price,
                    Discount = 0,
                    PriceExpiryDate = DateTime.Now.AddDays(7)
                };
                cart.CartItems.Add(cartItem);
            }
            return await _cartRepository.Update(cart);
        }

        public async Task<Cart> RemoveCartItem(int cartId, int productId)
        {
            Cart cart = await _cartRepository.GetByKey(cartId);
            CartItem cartItemToRemove = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItemToRemove != null)
            {
                cart.CartItems.Remove(cartItemToRemove);
                return await _cartRepository.Update(cart);
            }
            throw new NoCartItemFoundExeption();
        }

        public async Task<double> CalculateTotalAmountAfterDiscountAndShippingCharge(Cart cart)
        {
            double totalAmount = await CalculateCartProductAmount(cart);

            //Shipping Charge 100 if Total Amount is less than 100
            if (totalAmount < 100)
            {
                totalAmount += 100;
            }

            //5 percent discount if total is >1500 and product is 3
            int totalProductQuantity = cart.CartItems.Sum(item => item.Quantity);
            if (totalProductQuantity == 3 && totalAmount >= 1500)
            {
                double discount = totalAmount * 0.05; // 5% discount
                totalAmount -= discount;
            }
            return totalAmount;
        }

        public async Task<double> CalculateCartProductAmount(Cart cart)
        {
            double totalAmount = 0;

            foreach (var cartItem in cart.CartItems)
            {
                Product product = await _productRepository.GetByKey(cartItem.ProductId);
                double subtotal = cartItem.Quantity * product.Price;
                totalAmount += subtotal;
            }
            return totalAmount;
        }
    }
}
