using System.Collections.Generic;

namespace EM_HW14.Source.TypeShop.Base
{
    public class Checkout<T> where T : Product
    {
        // fields
        private static int autoInc = 1;
        public readonly int id = 0;
        private Receipt<T> currentReceipt;
        private readonly List<Receipt<T>> archive;

        // init
        public Checkout()
        {
            id = autoInc++;
            currentReceipt = new Receipt<T>();
            archive = new List<Receipt<T>>();
        }

        // funcs
        public void CreateReceipt()
        {
            if (currentReceipt.Length > 0) { archive.Add(currentReceipt); }
            currentReceipt.Clear();
        }
        public void ScanProduct(T product) { currentReceipt.AddProduct(product); }
        public Receipt<T> GetReceipt() { return new Receipt<T>(currentReceipt); }
    }
}
