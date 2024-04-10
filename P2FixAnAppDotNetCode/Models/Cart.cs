using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private readonly List<CartLine> _cartLines = new List<CartLine>();

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => _cartLines.AsReadOnly();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return new List<CartLine>();
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // TODO implement the method (finish)
            CartLine cartLine = _cartLines.FirstOrDefault(cl => cl.Product.Id == product.Id);

            if (cartLine != null)
            {
                cartLine.Quantity += quantity;
            }
            else
            {
                _cartLines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            _cartLines.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>

        // TODO implement the method (finish)
        public double GetTotalValue() => _cartLines.Sum(l => l.Product.Price * l.Quantity);

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            // TODO implement the method (finish)
            if (_cartLines.Count == 0) return 0;

            return GetTotalValue() / _cartLines.Sum(l => l.Quantity);
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>

        // TODO implement the method (finish)
        public Product FindProductInCartLines(int productId) =>_cartLines.FirstOrDefault(l => l.Product.Id == productId)?.Product;

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            _cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
