using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.FirstMethodSqlRepository
{
    class BusFMRepository : IBusDbManager
    {


        static VehicleFMRepository vfm = new VehicleFMRepository();
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino; Integrated Security=true;";

        public void Delete(Bus t)
        {
            throw new NotImplementedException();
        }

        public List<Bus> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Bus> FetchStaticList()
        {
            throw new NotImplementedException();
        }

        public Bus GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Bus buss = new Bus(bus.NumberOfSeats,bus.Brand, bus.Model, null);
                vfm.Insert(bus);
                int idBus = vfm.GetId(bus);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "insert into Bus values (@numberOfSeats)"; // errore
                command.Parameters.AddWithValue("@numberOfSeats", bus.NumberOfSeats);

                command.ExecuteNonQuery(); // chiamo query che non torna nulla

            }
        }

        public void Update(Bus t)
        {
            throw new NotImplementedException();
        }
    }
}
