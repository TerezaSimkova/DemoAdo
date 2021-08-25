using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario
{
    class Motorcycle : Vehicle
    {
        public int Year { get; set; }

        public Motorcycle(int year, string brand, string model,int? id)
            : base(brand, model,id)
        {
            Year = year;
        }

        public Motorcycle() { }

        internal override string Print()
        {
            return $"{base.Print()}, {Year}";
        }


    }

}
