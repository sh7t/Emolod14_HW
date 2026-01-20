using EM_HW14.Source.Utils;
using System;

namespace EM_HW14.Source.TypeShop.Base
{
    public abstract class Product
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        public readonly string name = "";
        public readonly int quantity = 0;
        public readonly double price = 0;

        // init
        public Product(string name, int quantity, double price)
        {
            if (ValidationHelper.IsNonPositive(name.Trim().Length)) { throw new Exception("Product name has to be at least 1 character."); }
            if (ValidationHelper.IsNegative(quantity)) { throw new Exception("Product quantity value must be positive."); }
            if (ValidationHelper.IsNonPositive(price)) { throw new Exception("Product price value must be greater than zero."); }

            this.name = name.Trim();
            this.quantity = quantity;
            this.price = price;

            id = autoInc++;
        }
    }
}
