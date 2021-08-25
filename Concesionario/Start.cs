using Concesionario.Repository;
using Concesionario.SecondMethodSqlRepository;
using Concesionario.ThirdMethodRepository;
using System;
using System.Collections.Generic;

namespace Concesionario
{
    internal class Start
    {
        //First method repository
        //static MotorcycleRepository mr = new MotorcycleRepository();
        //public static BusRepository br = new BusRepository();
        //static CarRepository cr = new CarRepository();

        //Second method repository
        //static MotorcycleSMRepository mr = new MotorcycleSMRepository();   
        //static CarSMRepository cr = new CarSMRepository();
        //static BusSMRepository br = new BusSMRepository();
        static VehicleRepository vr = new VehicleRepository();

        //Third repository method
        public static MotorcycleTMRepository mr = new MotorcycleTMRepository();
        public static CarTMRepository cr = new CarTMRepository();
        public static BusTMRepository br = new BusTMRepository();


        internal static void Menu()
        {
            bool continua = true;

            while (continua)
            {
                Console.WriteLine("\n***Welcome***");

                Console.WriteLine("Premi 1 per vedere tutti i Vehicle");
                Console.WriteLine("Premi 2 per vedere tutte le Motorcycle");
                Console.WriteLine("Premi 3 per vedere tutte le Auto");
                Console.WriteLine("Premi 4 per vedere tutti i Bus");
                Console.WriteLine("Premi 5 per inserire un nuovo veicolo");
                Console.WriteLine("Premi 6 per vendere un veicolo");
                Console.WriteLine("Premi 0 per uscire");

                int scelta;

                do
                {
                    Console.WriteLine("Fai la tua scelta");
                  
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta <0 || scelta >6);

                switch (scelta)
                {
                    case 0:
                        Console.WriteLine("********Arrivederci!*********");
                        continua = false;
                        break;
                    case 1:
                        List<Vehicle> vehicle = vr.Fetch();
                        PrintVehicles(vehicle);
                        break;
                    case 2:
                        List<Motorcycle> motorcycle = mr.Fetch();
                        PrintMoto(motorcycle);
                        break;
                    case 3:
                        List<Car> car = cr.Fetch();
                        PrintCar(car);
                        break;
                    case 4:
                        List<Bus> bus = br.Fetch();
                        PrintBus(bus);
                        break;
                    case 5:
                        DealerManager.InsertVehicle();
                        break;
                    case 6:
                        DealerManager.SellVehicle();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PrintVehicles(List<Vehicle> vehicle)
        {

            foreach (var v in vehicle)
            {
                Console.WriteLine(v.Print());
            }
        }

        private static void PrintBus(List<Bus> bus)
        {
            foreach (var b in bus)
            {
                Console.WriteLine(b.Print());
            }
        }

        private static void PrintCar(List<Car> car)
        {
            foreach (var c in car)
            {
                Console.WriteLine(c.Print());
            }
        }

        private static void PrintMoto(List<Motorcycle> motorcycle)
        {
            foreach (var moto in motorcycle)
            {
                Console.WriteLine(moto.Print());
            }
        }
    }
}