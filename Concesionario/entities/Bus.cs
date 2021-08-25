using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario
{
    class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(int numberOfSeats, string brand, string model, int? id)
            : base(brand, model, id)
        {
            NumberOfSeats = numberOfSeats;
        }

        public Bus() { }

        internal override string Print()
        {
            return $"{base.Print()}, Number of seats: {NumberOfSeats}";
        }
    }
}
