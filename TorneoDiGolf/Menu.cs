using System;

namespace TorneoDiGolf
{
    internal class Menu
    {
        internal static void Start()
        {

            

            int scelta;
            bool continua = true;

            do
            {
                Console.WriteLine("\n****Benvenuto*****");

                Console.WriteLine("Premi 1 per visualizzare tutti gli iscritti.");
                Console.WriteLine("Premi 2 per modificare i dati di un iscritto.");
                Console.WriteLine("Premi 3 per eliminare un iscritto.");
                Console.WriteLine("Premi 4 per inserire un nuovo utente.");
                Console.WriteLine("Premi 5 per avere dati di un iscritto secondo il nome e cognome.");
                Console.WriteLine("Premi 6 per filtrare gli iscritti tesserati.");
                Console.WriteLine("Premi 0 per uscire");

                do
                {
                    Console.WriteLine("\nCosa voresti fare?");

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 6);

                switch (scelta)
                {
                    case 0:
                        Console.WriteLine("***Arrivederci***");
                        continua = false;
                        break;
                    case 1:
                        UserManager.ShowAllUsers();
                        break;
                    case 2:
                        UserManager.UpdateUser();
                        break;
                    case 3:
                        UserManager.DeleteUser();
                        break;
                    case 4:
                        UserManager.InsertNewUser();
                        break;
                    case 5:
                        UserManager.FindSecondNameSurname();
                        break;
                    case 6:
                        UserManager.FilterTesserati();
                        break;

                }

            } while (continua);

        }
    }
}