using System;

namespace NegozioEletronica
{
    internal class Start
    {
        internal static void Menu()
        {

            bool continua=true;
            int scelta;
            while (continua)
            {
                Console.WriteLine("\n***Benvenuti***\n");

                Console.WriteLine("Premi 1 per visualizzare tutti i prodotti.");
                Console.WriteLine("Premi 2 per visualizzare tutti i cellulari.");
                Console.WriteLine("Premi 3 per visualizzare tuttí i Pc.");
                Console.WriteLine("Premi 4 per visualizzare tutte le Tv.");
                Console.WriteLine("Premi 5 per inserire un nuovo prodotto.");
                Console.WriteLine("Premi 6 per modificare un prodotto.");
                Console.WriteLine("Premi 7 per eliminare un prodotto.");
                Console.WriteLine("Premi 8 per filtrare i cellulari per la memoria superiore a quella scelta.");
                Console.WriteLine("Premi 9 per filtrare i pc per sistema operativo scleto dal cliente.");
                Console.WriteLine("Premi 10 per filtrare le tv per polici uguali a quelli scelti dal utente.");
                Console.WriteLine("Premi 0 per uscire.");

                do
                {
                    Console.WriteLine("\nCosa scegli di fare?");

                } while (!int.TryParse(Console.ReadLine(),out scelta) || scelta <0 || scelta > 10);
                

                switch (scelta)
                {
                    case 1:
                        ManagerSystem.ShowProducts();
                        break;
                    case 2:
                        ManagerSystem.ShowPhones();
                        break;
                    case 3:
                        ManagerSystem.ShowPc();
                        break;
                    case 4:
                        ManagerSystem.ShowTv();
                        break;
                    case 5:
                        ManagerSystem.InsertNewProduct();
                        break;
                    case 6:
                        ManagerSystem.UpdateProduct();
                        break;
                    case 7:
                        ManagerSystem.DeleteProduct();
                        break;
                    case 8:
                        //ManagerSystem.FilterByMemory();
                        break;
                    case 9:
                        //ManagerSystem.FilterByOPSystem();
                        break;
                    case 10:
                        //ManagerSystem.FilterByInch();
                        break;
                    case 0:
                        Console.WriteLine("***Arrivederci***");
                        continua = false;
                        break;

                }

             
            }

        }
    }
}