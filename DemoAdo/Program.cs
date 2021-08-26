using System;

namespace DemoAdo
{
    class Program
    {
        static void Main(string[] args)
        {

            DisconnectedMode discon = new DisconnectedMode();

            discon.fetch();
            discon.Insert();
            //DbManagerConnectedMode dbm = new DbManagerConnectedMode();

            //dbm.fetch();

            //dbm.GetById(1);

            //dbm.Insert("1984", "George Orwel", 18);

            //Book book = new Book("Decameron", "Giovanni Boccaccio", 32,4);
            //dbm.Update(book);

            //dbm.Count();

        }
    }
}
