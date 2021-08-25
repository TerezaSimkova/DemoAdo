using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.Repository
{
    class CarRepository : IdbManager<Car>
    {
        static List<Car> cars = new List<Car>()
        {
            new Car(
                Car.PowerSupply.Gassoline,
                2,
                "Lamborghini",
                "Sport",
                3
                ),
            new Car(
                Car.PowerSupply.Diesel,
                4,
                "Passat",
                "Road",
                4
                )
        };

        public void Delete(Car car)
        {
            cars.Remove(car);
        }

        public List<Car> Fetch()
        {
            return cars;
        }

        public List<Car> FetchStaticList()
        {
            return cars;
        }

        public Car GetById(int? id)
        {
            return cars.Find(c => c.Id == id);
        }

        public void Insert(Car car)
        {
            cars.Add(car);
        }

        public void Update(Car car)
        {
            Delete(GetById(car.Id));
            Insert(car);
        }
    }
}
