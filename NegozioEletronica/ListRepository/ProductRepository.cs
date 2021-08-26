using NegozioEletronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica.ListRepository
{
    class ProductRepository : IProductRepository
    {
        static public PhoneRepository phoneR = new PhoneRepository();
        static public TvRepository tvR = new TvRepository();
        static public PcRepository pcR = new PcRepository();

        static List<Product> products = new List<Product>();

        public void Delete(Product product)
        {
            products.Remove(product);
        }

        public List<Product> Fetch()
        {

            products.AddRange(phoneR.Fetch());
            products.AddRange(tvR.Fetch());
            products.AddRange(pcR.Fetch());

            return products;
        }

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            Insert(product);
        }
    }
}

