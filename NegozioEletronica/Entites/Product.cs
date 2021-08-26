using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica
{
    class Product
    {
        public int? Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }

        public Product(int? id, string brand, string model, int quantity)
        {
            Id = id;
            Brand = brand; ;
            Model = model;
            Quantity = quantity;
        }

        public Product() { }

        public virtual string Print()
        {
            return $"{Brand} - {Model} - {Quantity}";
        }
    }
}
