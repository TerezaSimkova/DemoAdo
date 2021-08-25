using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario
{
    class Car : Vehicle
    {
        public PowerSupply Supply { get; set; }
        public int NumberOfDoors { get; set; }


        public Car(PowerSupply supply, int numberOfDoors, string brand, string model, int? id)
            : base(brand, model, id)
        {
            Supply = supply;
            NumberOfDoors = numberOfDoors;
        }

        public Car() { }
    
        public enum PowerSupply
        {
            Diesel,
            Gassoline,
            Electric
        }

        internal override string Print()
        {
            return $"{base.Print()}, Power Supply: {Supply}, Number of doors: {NumberOfDoors}";
        }


    }
}
