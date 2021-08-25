using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.Repository
{
    class VehicleRepository : IdbManager<Vehicle>
    {
        static List<Vehicle> vehicles = new List<Vehicle>();

        public static MotorcycleRepository mr = new MotorcycleRepository();
        public static  CarRepository cr = new CarRepository();
        public static BusRepository br = new BusRepository();      

        public List<Vehicle> Fetch()
        {
        
            vehicles.AddRange(mr.Fetch());
            vehicles.AddRange(cr.Fetch());
            vehicles.AddRange(br.Fetch());
            return vehicles;
        }

        public List<Vehicle> FetchStaticList()
        {

            return vehicles;
        }

        public Vehicle GetById(int? id)
        {
           return vehicles.Find(v => v.Id == id);
        }

        public void Insert(Vehicle vehicle)
        {
            //vehicles.Add(vehicle);
        }

        public void Delete(Vehicle t)
        {
            //throw new NotImplementedException();
        }

        public void Update(Vehicle t)
        {
            //throw new NotImplementedException();
        }
    }
}
