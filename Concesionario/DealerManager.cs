using Concesionario.FirstMethodSqlRepository;
using Concesionario.Repository;
using Concesionario.SecondMethodSqlRepository;
using Concesionario.ThirdMethodRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using static Concesionario.Car;

namespace Concesionario
{

    internal class DealerManager
    {
        //public static MotorcycleRepository mr = new MotorcycleRepository();
        //public static CarRepository cr = new CarRepository();
        //public static BusRepository br = new BusRepository();
        public static VehicleRepository vr = new VehicleRepository();

        /*public static MotorcycleFMRepository mr = new MotorcycleFMRepository();*/ //classe che viene istanziata
        //public static BusFMRepository br = new BusFMRepository();
        //public static BusSMRepository br = new BusSMRepository();
        //public static MotorcycleSMRepository mr = new MotorcycleSMRepository();
        //public static CarSMRepository cr = new CarSMRepository();

        //Third repository method
        public static MotorcycleTMRepository mr = new MotorcycleTMRepository();
        public static CarTMRepository cr = new CarTMRepository();
        public static BusTMRepository br = new BusTMRepository();


        internal static void InsertVehicle()
        {
            bool continua = true;
            while (continua)
            {

                Console.WriteLine("Vuoi inserire moto? Premi 1!");
                Console.WriteLine("Vuoi inserire auto? Prmei 2!");
                Console.WriteLine("Vuoi inserire bus? Premi 3!");

                int scelta;

                do
                {
                    Console.WriteLine("Quale veicolo vuoi inserire?");

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 3);

                switch (scelta)
                {
                    case 1:
                        Motorcycle motorcycle = InsertMoto();
                        mr.Insert(motorcycle);
                        break;
                    case 2:
                        Car car = InsertCar();
                        cr.Insert(car);
                        break;
                    case 3:
                        Bus bus = InsertBus();
                        br.Insert(bus);
                        break;
                }
                continua = false;
            }

        }

        private static Bus InsertBus()
        {
            Vehicle vehicle = ChiediDatiVeicolo();
            Bus bus = new Bus();
            bus.Brand = vehicle.Brand;
            bus.Model = vehicle.Model;

            bool isInt;
            int NumberOfSeats;

            do
            {
                Console.WriteLine("Inserisci numero di posti.");
                isInt = int.TryParse(Console.ReadLine(), out NumberOfSeats);

            } while (!isInt);

            bus.NumberOfSeats = NumberOfSeats;
            return bus;
        }

        private static Car InsertCar()
        {
            Vehicle vehicle = ChiediDatiVeicolo();
            Car car = new Car();
            car.Brand = vehicle.Brand;
            car.Model = vehicle.Model;

            bool NumberDoors = true;
            int num;
            do
            {
                Console.WriteLine("Inserisci il numero delle porte.");
                NumberDoors = int.TryParse(Console.ReadLine(), out num);

            } while (!NumberDoors);

            car.NumberOfDoors = num;

            bool isInt;
            int supply;
            do
            {
                Console.WriteLine("Inserisci il tipo di carburante.");
                foreach (var genere in Enum.GetValues(typeof(PowerSupply)))
                {
                    Console.WriteLine($"Premi {(int)genere + 1} per {(PowerSupply)genere}");
                }
                isInt = int.TryParse(Console.ReadLine(), out supply);

            } while (!isInt || supply <= 0 || supply > 4);
            return car;
        }

        private static Motorcycle InsertMoto()
        {
            Vehicle vehicle = ChiediDatiVeicolo();

            Motorcycle motorcycle = new Motorcycle();
            motorcycle.Brand = vehicle.Brand;
            motorcycle.Model = vehicle.Model;

            bool isInt;
            int annoDiProduzione;

            do
            {
                Console.WriteLine("Inserisci l'anno in cui é stato prodotto.");
                isInt = int.TryParse(Console.ReadLine(), out annoDiProduzione);

            } while (!isInt);

            motorcycle.Year = annoDiProduzione;
            return motorcycle;
        }

        private static Vehicle ChiediDatiVeicolo()
        {
            Vehicle vehicle = new Vehicle();

            Console.WriteLine("Inserisci il Brand:");
            vehicle.Brand = Console.ReadLine();

            Console.WriteLine("Inserisci il Modello:");
            vehicle.Model = Console.ReadLine();

            return vehicle;
        }


        internal static void SellVehicle()
        {
            int tipoVeicolo;
            bool isInt;

            do
            {
                Console.WriteLine("Che veicolo vuoi acquistare?");
                Console.WriteLine("Premi 1 per acquistare una moto");
                Console.WriteLine("Premi 2 per acquistare un'auto");
                Console.WriteLine("Premi 3 per acquistare un pulmino");

                isInt = int.TryParse(Console.ReadLine(), out tipoVeicolo);

            } while (!isInt || tipoVeicolo <= 0 || tipoVeicolo >= 4);

            switch (tipoVeicolo)
            {
                case 1:
                    Motorcycle motocycle = ScegliMoto();
                    mr.Delete(motocycle);
                    break;
                case 2:
                    Car car = ScegliAuto();
                    cr.Delete(car);
                    break;
                case 3:
                    Bus bus = ScegliBus();
                    br.Delete(bus);
                    break;
            }
        }

        private static Bus ScegliBus()
        {
            List<Bus> buses = br.Fetch();
            int i = 1;
            foreach (var bus in buses)
            {
                Console.WriteLine($"Premi {i} per aquistare {bus.Print()}");
                i++;
            }
            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > buses.Count);

            return buses.ElementAt(veicoloScelto - 1);

        }

        private static Car ScegliAuto()
        {
            List<Car> cars = cr.Fetch();

            int i = 1;
            foreach (var car in cars)
            {
                Console.WriteLine($"Premi {i} per acquistare {car.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > cars.Count);

            return cars.ElementAt(veicoloScelto - 1);
        }

        private static Motorcycle ScegliMoto()
        {
            List<Motorcycle> motocycles = mr.Fetch();

            int i = 1;
            foreach (var motocycle in motocycles)
            {
                Console.WriteLine($"Premi {i} per acquistare {motocycle.Print()}");
                i++;
            }

            bool isInt;
            int veicoloScelto;
            do
            {
                Console.WriteLine("Quale veicolo vuoi acquistare?");

                isInt = int.TryParse(Console.ReadLine(), out veicoloScelto);

            } while (!isInt || veicoloScelto <= 0 || veicoloScelto > motocycles.Count);

            return motocycles.ElementAt(veicoloScelto - 1);

        }
    }
    
}