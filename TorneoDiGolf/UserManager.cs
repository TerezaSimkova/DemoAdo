using System;
using System.Collections.Generic;
using System.Linq;

namespace TorneoDiGolf
{
    internal class UserManager
    {

        //public static UserRepository userRep = new UserRepository();
        public static UserGRepository userRep = new UserGRepository();

        internal static void ShowAllUsers()
        {
            List<User> users = userRep.Fetch();
            foreach (var user in users)
            {
                Console.WriteLine(user.Print());
            }
        }

        public static void UpdateUser()
        {
            List<User> users = userRep.Fetch();

            int i = 1;
            foreach (var u in users)
            {
                Console.WriteLine($"Premi {i} per scegliere {u.Print()}");
                i++;
            }
            int scelta;
            bool isInt;
            do
            {
                Console.WriteLine("Quale utente vuoi modificare?");
                isInt = int.TryParse(Console.ReadLine(), out scelta);

            } while (!isInt || scelta <= 0 || scelta > users.Count);
            Console.WriteLine("Hai scelto di modificare questo utente.");
            User user = users.ElementAt(scelta - 1);
            if (user.Id == null)
            {
                userRep.Delete(user);
            }

            bool continua = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi cambiare il nome?");
                risposta = Console.ReadLine();
                if (risposta == "No")
                {
                    continua = false;

                }
                else if (risposta == "Si")
                {
                    user.Name = UpdateName();
                }

            } while (continua);
            do
            {
                Console.WriteLine("Vuoi cambiare il cognome?");
                risposta = Console.ReadLine();
                if (risposta == "No")
                {
                    continua = false;

                }
                else if (risposta == "Si")
                {
                    user.Surname = UpdateCognome();
                }

            } while (continua);
            do
            {
                Console.WriteLine("Vuoi cambiare il l'anno di nascita?");
                risposta = Console.ReadLine();
                if (risposta == "No")
                {
                    continua = false;

                }
                else if (risposta == "Si")
                {
                    user.DateOfBirth = UpdateDate();
                }

            } while (continua);
            do
            {
                Console.WriteLine("Vuoi cambiare il sesso?");
                risposta = Console.ReadLine();
                if (risposta == "No")
                {
                    continua = false;

                }
                else if (risposta == "Si")
                {
                    user.Gender = UpdateGen();
                }

            } while (continua);
            do
            {
                Console.WriteLine("Vuoi cambiare sé tessarato?");
                risposta = Console.ReadLine();
                if (risposta == "No")
                {
                    continua = false;

                }
                else if (risposta == "Si")
                {
                    user.ClubCard = UpdateClubC();
                }

            } while (continua);

            userRep.Update(user);
        }

        internal static void FilterTesserati()
        {
            List<User> users = userRep.Fetch();
            List<User> userses = UserRepository.filtraPerTrue();
            foreach (var us in userses)
            {
                Console.WriteLine(us.Print());
            }
            

        }

        internal static void FindSecondNameSurname()
        {
            List<User> users = userRep.Fetch();

            string name;
            string surname;
            Console.WriteLine("Inserisci il nome:");
            name = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome:");
            surname = Console.ReadLine();
            if (name == null || surname == null)
            {
                Console.WriteLine("Non esiste una persona con questo nome e cognome.");
            }
            else
            {
                User user = UserRepository.FindByNameAndSurname(name, surname);
                Console.WriteLine("Hai scelto:");
                Console.WriteLine(user.Print());

            }

        }

        private static bool UpdateClubC()
        {
            bool clubCard;
            do
            {
                Console.WriteLine("Inserisci false per NO / true per SI:");

            } while (!bool.TryParse(Console.ReadLine(), out clubCard));
            return clubCard;
        }

        private static EnumGender UpdateGen()
        {
            int s = 0;
            Console.WriteLine("Premi 0  per maschio o 1 per femmina:");
            
            while (!int.TryParse(Console.ReadLine(), out s))
            {
                Console.WriteLine("Sbagliato! Riprova!");
            }
            return (EnumGender)s;
        }

        private static DateTime UpdateDate()
        {
            DateTime dt = new DateTime();

            Console.WriteLine("Inserisci nuova data di nascita yy/dd/mm:");
            dt = DateTime.Parse(Console.ReadLine());
            return dt;

        }

        private static string UpdateCognome()
        {
            String surname = String.Empty;
            do
            {
                Console.WriteLine("Inserisci nuovo cognome:");
                surname = Console.ReadLine();

            } while (String.IsNullOrEmpty(surname));
            return surname;
        }

        private static string UpdateName()
        {
            String name = String.Empty;
            do
            {
                Console.WriteLine("Inserisci nuovo nome:");
                name = Console.ReadLine();

            } while (String.IsNullOrEmpty(name));
            return name;
        }

        internal static void DeleteUser()
        {
            User users = DeleteUsers();
            userRep.Delete(users);
        }

        private static User DeleteUsers()
        {
            List<User> users = userRep.Fetch();

            int i = 1;
            foreach (var u in users)
            {
                Console.WriteLine($"Premi {i} per scegliere {u.Print()}");
                i++;
            }

            bool isInt;
            int scelta;
            do
            {
                Console.WriteLine("Quale user vuoi eliminare?");

                isInt = int.TryParse(Console.ReadLine(), out scelta);

            } while (!isInt || scelta <= 0 || scelta > users.Count);

            return users.ElementAt(scelta - 1);
        }

        internal static void InsertNewUser()
        {
            User user = UserData();
            userRep.Insert(user);
        }

        private static User UserData()
        {
            User user = new User();

            string name;
            string surname;
            DateTime dt = new DateTime();
            bool clubCard;
            bool isInt;


            Console.WriteLine("Inserisci il nome:");
            name = Console.ReadLine();
            user.Name = name;

            Console.WriteLine("Inserisci cognome:");
            surname = Console.ReadLine();
            user.Surname = surname;

            Console.WriteLine("Inderisci data di nascita:");
            dt = DateTime.Parse(Console.ReadLine());
            user.DateOfBirth = dt;

            Console.WriteLine("Inderisci il sesso:");
            Console.WriteLine("Premi 0 maschio o 1 femmina:");
            int s = 0;
            while (!int.TryParse(Console.ReadLine(), out s))
            {
                Console.WriteLine("Sbagliato! Riprova!");
            }
            user.Gender = (EnumGender)s;

            do
            {
                Console.WriteLine("Inserisci se nuovo utente é tessarato o no:");
                Console.WriteLine("Inserisci 'false' per NO e 'true' per SI.");

            } while (!bool.TryParse(Console.ReadLine(), out clubCard));
            user.ClubCard = clubCard;

            return user;
        }
    }
}