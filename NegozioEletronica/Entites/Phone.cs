using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica
{
    class Phone : Product
    {
        public int MemoryGB { get; set; }

        public Phone(int? id, string brand, string model, int quantity, int memoryGB)
            : base(id, brand, model, quantity)
        {

            MemoryGB = memoryGB;
        }

        public Phone() { }

        public override string Print()
        {
            return $"{ base.Print()} - {MemoryGB}";
        }
    }
}
