using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.FirstMethodSqlRepository
{
    class MotorcycleFMRepository : IMotocycleDbManager
    {

        static VehicleFMRepository vfm = new VehicleFMRepository();

        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino; Integrated Security=true;"; //db adress,nome del DB,sicurezza

        public void Delete(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int idVehicleToDelete = GetIdVehicle(motorcycle.Id); // chiamo

                //cancella moto
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "delete from Motorcycle where Id = @id";
                command.Parameters.AddWithValue("@id", motorcycle.Id);

                command.ExecuteNonQuery(); // chiamo query che non torna nulla

                vfm.DeleteById(idVehicleToDelete); //delte della tabela vehicle
            }
        }

        private int GetIdVehicle(int? id)
        {
            int idVehicleToDelete=0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Motorcycle where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicleToDelete = (int)reader["IdVehicle"]; 
                }
            }
            return idVehicleToDelete;
        }

        public List<Motorcycle> Fetch()
        {
            List<Motorcycle> mororcycles = new List<Motorcycle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select vehicle.Brand, vehicle.Model,Motorcycle.Id,Motorcycle.ProductionYear from dbo.Vehicle join dbo.Motorcycle on vehicle.Id = Motorcycle.IdVehicle";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = reader["Brand"];
                    var model = reader["Model"];
                    var year = (int)reader["Year"];
                    var id = (int)reader["Id"];

                    Motorcycle motorcycle = new Motorcycle(year, (string)brand, (string)model, id);

                    mororcycles.Add(motorcycle);
                }
            }
            return mororcycles;
        }

        public List<Motorcycle> FetchStaticList()
        {
            throw new NotImplementedException();
        }

        public Motorcycle GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Vehicle vehicle = new Vehicle(motorcycle.Brand, motorcycle.Model, null);
                vfm.Insert(vehicle);
                int idVehicle = vfm.GetId(vehicle);

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "insert into Motorcycle values (@year, @idVehicle)";
                command.Parameters.AddWithValue("@year", motorcycle.Year);
                command.Parameters.AddWithValue("@idVehicle", idVehicle);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Motorcycle t)
        {
            throw new NotImplementedException();
        }
    }
}
