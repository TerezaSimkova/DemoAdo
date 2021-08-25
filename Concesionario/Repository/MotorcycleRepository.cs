using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.Repository
{
    class MotorcycleRepository : IdbManager<Motorcycle>
    {
        static List<Motorcycle> motorcycles = new List<Motorcycle>()
        {
            new Motorcycle(
                2017,
                "Ducati",
                "Adventure",
                1
                ),
            new Motorcycle(
                2018,
                "Kawasaki",
                "Cross",
                2
                )
        };

        public void Delete(Motorcycle motorcycle)
        {
            motorcycles.Remove(motorcycle);
        }

        public List<Motorcycle> Fetch()
        {
            return motorcycles;
        }

        public Motorcycle GetById(int? id)
        {
            return motorcycles.Find(m => m.Id == id);

        }

        public List<Motorcycle> FetchStaticList()
        {
            return motorcycles;
        }

        public void Insert(Motorcycle motorcycle)
        {
            motorcycles.Add(motorcycle);
        }

        public void Update(Motorcycle motorcycle)
        {
            // moto vecchia, con i vecchi parametri
            var motoDaCancellare = GetById(motorcycle.Id);

            Delete(motoDaCancellare);

            //Moto con i nuovi parametri
            Insert(motorcycle);
        }

    
    }
}
