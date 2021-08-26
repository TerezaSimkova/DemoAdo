using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoDiGolf
{
    class UserRepository : IUserDbManager<User>
    {
        static List<User> users = new List<User>()
        {
            new User(
                1,
                "Kevin",
                "Stone",
                new DateTime(1995,6,28),
                EnumGender.female,
                true               
                ),
            new User(                
                2,
                "Laura",
                "Rossi",
                new DateTime(1992,2,15),
                EnumGender.male,
                false
                ),
            new User(
                3,
                "Monica",
                "Neri",
                new DateTime(1999,3,25),
                EnumGender.female,
                true
                )
        };

        public void Delete(User user)
        {
            users.Remove(user);
        }

        public List<User> Fetch()
        {
            return users;
        }

        public User GetById(int? id)
        {
            return users.Find(u => u.Id == id);
        }

        public void Insert(User user)
        {
            users.Add(user);
        }

        public void Update(User user)
        {
            Delete(GetById(user.Id));
            Insert(user);
        }


        public static User FindByNameAndSurname(string name, string surname)
        {
            return users.Find(u => u.Name == name && u.Surname == surname);
        }

        internal static List<User> filtraPerTrue()
        {
            return users.Where(u => u.ClubCard == true).ToList();
        }
    }
}
