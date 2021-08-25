using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.Repository
{
    class BusRepository : IdbManager<Bus>
    {
        static List<Bus> buses= new List<Bus>()
        {
            new Bus(
                42,
                "Toyota",
                "School",
                5
                ),
            new Bus(
                56,
                "Chana",
                "Night bus",
                6
                )
        };

        public void Delete(Bus bus)
        {
            buses.Remove(bus);
        }

        public List<Bus> Fetch()
        {
            return buses;
        }

        public List<Bus> FetchStaticList()
        {
            return buses;
        }

        public Bus GetById(int? id)
        {
            return buses.Find(b => b.Id == id);
        }

        public void Insert(Bus bus)
        {
            buses.Add(bus);
        }

        public void Update(Bus bus)
        {
            Delete(GetById(bus.Id));
            Insert(bus);
        }
    }
}
