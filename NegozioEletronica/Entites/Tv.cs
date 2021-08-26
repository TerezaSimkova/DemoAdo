using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica
{
    class Tv : Product
    {
        public int InchTV { get; set; }

        public Tv(int? id, string brand, string model, int quantity, int inchTV)
            : base(id, brand, model, quantity)
        {
            InchTV = inchTV;
        }

        public Tv() { }

        public override string Print()
        {
            return $"{ base.Print()} - {InchTV}";
        }
    }
}
