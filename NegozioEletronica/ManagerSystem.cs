using NegozioEletronica.ListRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NegozioEletronica
{
    internal class ManagerSystem
    {

        static public PhoneRepository phoneR = new PhoneRepository();
        static public TvRepository tvR = new TvRepository();
        static public PcRepository pcR = new PcRepository();
        static public ProductRepository prods = new ProductRepository();
        internal static void ShowProducts()
        {
            List<Product> products = prods.Fetch();
            foreach (var prod in products)
            {
                Console.WriteLine(prod.Print());
            }
        }

        internal static void ShowPhones()
        {
            List<Phone> phones = phoneR.Fetch();
            foreach (var ph in phones)
            {
                Console.WriteLine(ph.Print());
            }
        }

        internal static void ShowPc()
        {
            List<Pc> pcs = pcR.Fetch();
            foreach (var pc in pcs)
            {
                Console.WriteLine(pc.Print());
            }
        }

        internal static void ShowTv()
        {
            List<Tv> tvs = tvR.Fetch();
            foreach (var tv in tvs)
            {
                Console.WriteLine(tv.Print());
            }
        }

        internal static void InsertNewProduct()
        {
            int scelta;

            do
            {
                Console.WriteLine("Quale prodotto vuoi inserire?");
                Console.WriteLine("Premi 1 per Cellulare / 2 per TV / 3 per PC");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 3);


            switch (scelta)
            {
                case 1:
                    InserireCell();
                    break;
                case 2:
                    InserisciTv();
                    break;
                case 3:
                    InserisciPc();
                    break;
            }
        }

        private static void InserisciPc()
        {
            Pc pc = new Pc();
            pc.Brand = Brand();
            pc.Model = Model();
            pc.Quantity = Quantity();

            int system;
            bool touch;

            do
            {
                Console.WriteLine("Inserisci il systema operativo 1-Windows/ 2-Mac / 3-Linux");

            } while (!int.TryParse(Console.ReadLine(), out system) || system < 1 || system > 3);
            pc.OPSystem = (EnumOP)system;

            do
            {
                Console.WriteLine("Inserisci se il Pc é touch: true per 'SI' / false per 'No'");

            } while (bool.TryParse(Console.ReadLine(), out touch));
            pc.Touch = touch;

            pcR.Insert(pc);
        }

        internal static void DeleteProduct()
        {
            int scelta;

            do
            {
                Console.WriteLine("Quale prodotto vuoi eliminare? Scegli 1 per Cellulare/ 2 per Pc / 3 per TV\n");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3);
            switch (scelta)
            {
                case 1:
                    Phone choosePhone = ChooseCell();
                    phoneR.Delete(choosePhone);
                    break;
                case 2:
                    Pc choosePc = ChoosePc();
                    pcR.Delete(choosePc);
                    break;
                case 3:
                    Tv chooseTv = ChooseTv();
                    tvR.Delete(chooseTv);
                    break;

            }
        }

        internal static void UpdateProduct()
        {
            int scelta;
            
            do
            {
                Console.WriteLine("Quale prodotto vuoi modificare? Scegli 1 per Cellulare/ 2 per Pc / 3 per TV");

            } while (!int.TryParse(Console.ReadLine(), out scelta)|| scelta<1 || scelta >3);
            switch (scelta)
            {
                case 1:
                    Phone choosePhone = ChooseCell();
                    if (choosePhone.Id == null)
                    {
                        phoneR.Delete(choosePhone);
                    }
                    Phone phone = ChangeDataPhone(choosePhone);
                    phoneR.Update(phone);
                    break;
                case 2:
                    Pc choosePc = ChoosePc();
                    if (choosePc.Id == null)
                    {
                        pcR.Delete(choosePc);
                    }
                    Pc pc = ChangeDataPc(choosePc);
                    pcR.Update(pc);
                    break;
                case 3:
                    Tv chooseTv = ChooseTv();
                    if (chooseTv.Id == null)
                    {
                        tvR.Delete(chooseTv);
                    }
                    Tv tv = ChangeDataTv(chooseTv);
                    tvR.Update(tv);
                    break;
            }
        }

        private static Tv ChangeDataTv(Tv chooseTv)
        {
            bool continua;
            int scelta;

            do
            {
                Console.WriteLine("Scegli 1 - per Brand/ 2 per Model /3 - per Quantitá in magazziono /4 - per inch della Tv");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 4);
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il brand:");
                    chooseTv.Brand = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Inserisci il model:");
                    chooseTv.Model = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Inserisci la quantitá in magazzino:");
                    chooseTv.Quantity = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Inserisci quanti inch ha TV:");
                    chooseTv.InchTV = int.Parse(Console.ReadLine());
                    break;
            }

            return chooseTv;
        }

        private static Tv ChooseTv()
        {
            List<Tv> tvs = tvR.Fetch();
            int i = 1;
            foreach (var p in tvs)
            {
                Console.WriteLine($"Premi {i} per {p.Print()}");
                i++;
            }

            bool isInt;
            int tvChosen;
            do
            {
                Console.WriteLine("Quale computer vuoi modificare/eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out tvChosen);

            } while (!isInt || tvChosen <= 0 || tvChosen > tvs.Count);

            return tvs.ElementAt(tvChosen - 1);
        }

        private static Pc ChangeDataPc(Pc choosePc)
        {
            bool continua;
            int scelta;

            do
            {
                Console.WriteLine("Scegli 1 - per Brand/ 2 per Model /3 - per Quantitá in magazziono /4 - per systema operativo /5- per lo schreen touch");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 4);
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il brand:");
                    choosePc.Brand = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Inserisci il model:");
                    choosePc.Model = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Inserisci la quantitá in magazzino:");
                    choosePc.Quantity = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    int system;
                    do
                    {
                        Console.WriteLine("Inserisci il systema operativo 1-Windows/ 2-Mac / 3-Linux");

                    } while (!int.TryParse(Console.ReadLine(), out system) || system < 1 || system > 3);
                    choosePc.OPSystem = (EnumOP)system;

                    break;
                case 5:
                    bool touch;
                    do
                    {
                        Console.WriteLine("Inserisci se il Pc é touch: true per 'SI' / false per 'No'");

                    } while (bool.TryParse(Console.ReadLine(), out touch));
                    choosePc.Touch = touch;
                    break;
            }

            return choosePc;
        }

        private static Pc ChoosePc()
        {
            List<Pc> pcs = pcR.Fetch();
            int i = 1;
            foreach (var p in pcs)
            {
                Console.WriteLine($"Premi {i} per {p.Print()}");
                i++;
            }

            bool isInt;
            int pcChosen;
            do
            {
                Console.WriteLine("Quale computer vuoi modificare/eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out pcChosen);

            } while (!isInt || pcChosen <= 0 || pcChosen > pcs.Count);

            return pcs.ElementAt(pcChosen - 1);
        }

        private static Phone ChangeDataPhone(Phone choosePhone)
        {
            bool continua;
            int scelta;

            do
            {
                Console.WriteLine("Scegli 1 - per Brand/ 2 per Model /3 - per Quantitá in magazziono /4 - per Memory in GB");

            } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 4);
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il brand:");
                    choosePhone.Brand = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Inserisci il model:");
                    choosePhone.Model = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Inserisci la quantitá in magazzino:");
                    choosePhone.Quantity = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Inserisci GB di memoria:");
                    choosePhone.MemoryGB = int.Parse(Console.ReadLine());
                    break;
            }

            return choosePhone;
        }

        private static Phone ChooseCell()
        {
            List<Phone> phones = phoneR.Fetch();
            int i = 1;
            foreach (var p in phones)
            {
                Console.WriteLine($"Premi {i} per {p.Print()}");
                i++;
            }

            bool isInt;
            int phoneChosen;
            do
            {
                Console.WriteLine("Quale cellulare vuoi modificare/eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out phoneChosen);

            } while (!isInt || phoneChosen <= 0 || phoneChosen > phones.Count);

            return phones.ElementAt(phoneChosen - 1);

        }

        private static void InserisciTv()
        {
            Tv tv = new Tv();
            tv.Brand = Brand();
            tv.Model = Model();
            tv.Quantity = Quantity();

            int inch;
            do
            {
                Console.WriteLine("Inserisci i polici in Inch:");

            } while (!int.TryParse(Console.ReadLine(), out inch));
            tv.InchTV = inch;

            tvR.Insert(tv);
        }

        private static void InserireCell()
        {
            Phone phone = new Phone();
            phone.Quantity = Quantity();
            phone.Brand = Brand();
            phone.Model = Model();

            int memory;

            do
            {
                Console.WriteLine("Inserisci la memoria del cellulare in GB:");

            } while (!int.TryParse(Console.ReadLine(), out memory));
            phone.MemoryGB = memory;

            phoneR.Insert(phone);
        }

        private static string Model()
        {
            String model = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il modello:");
                model = Console.ReadLine();

            } while (String.IsNullOrEmpty(model));
            return model;

        }

        private static string Brand()
        {
            String brand = String.Empty;

            do
            {
                Console.WriteLine("Inserisci la marca:");
                brand = Console.ReadLine();

            } while (String.IsNullOrEmpty(brand));
            return brand;

        }

        private static int Quantity()
        {
            int quantity;
            do
            {
                Console.WriteLine("Inserisci la quantitá nel magazzino:");

            } while (!int.TryParse(Console.ReadLine(), out quantity)); ;
            return quantity;

        }

    }
}