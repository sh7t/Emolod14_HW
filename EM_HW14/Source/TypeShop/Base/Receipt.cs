using EM_HW14.Source.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EM_HW14.Source.TypeShop.Base
{
    public class Receipt<T> where T : Product
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        private readonly List<T> receipt;


        // init
        public Receipt()
        {
            id = autoInc++;
            receipt = new List<T>();
        }
        public Receipt(Receipt<T> src)
        {
            ValidationHelper.CheckForNull(src);

            id = autoInc++;
            receipt = new List<T>(src.receipt);
        }

        // getset / properties
        public int Length => receipt.Count();
        public double Cost => receipt.Sum(product => product.price);

        // funcs
        public void Clear() { receipt.Clear(); }
        public void AddProduct(T product)
        {
            if (receipt.Any(p => p.id == product.id)) { throw new Exception($"Product (ID{product.id}) is already exists in receipt."); }
            receipt.Add(product);
        }

    }
}
