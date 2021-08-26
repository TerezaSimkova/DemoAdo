using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica
{
    class Pc : Product
    {
        public EnumOP OPSystem { get; set; }
        public bool Touch { get; set; }

        public Pc(int? id, string brand, string model, int quantity, EnumOP opsystem, bool touch)
            : base(id, brand, model, quantity)
        {
            OPSystem = opsystem;
            Touch = touch;
        }

        public Pc() { }


        public override string Print()
        {
            return $"{ base.Print()} - {OPSystem} - {Touch}";
        }


    }
    public enum EnumOP
    {
        Windows = 1,
        Mac = 2,
        Linux = 3
    }


   
}
