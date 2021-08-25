using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.FirstMethodSqlRepository
{
    class VehicleFMRepository : IVehicleDbManager  //delete dalla tabella vehicle
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino; Integrated Security=true;";

        public void Delete(Vehicle t)
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> Fetch()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> FetchStaticList()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "insert into Vehicle values (@brand, @model)";
                command.Parameters.AddWithValue("@brand",vehicle.Brand);
                command.Parameters.AddWithValue("@model",vehicle.Model);

                command.ExecuteNonQuery(); // chiamo query che non torna nulla

            }
        }

        public void Update(Vehicle t)
        {
            throw new NotImplementedException();
        }

        internal void DeleteById(int idVehicleToDelete)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "delete from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", idVehicleToDelete);

                command.ExecuteNonQuery(); 
            }

    }

        internal int GetId(Vehicle vehicle)
        {
            int idVehicle = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Id from vehicle where Brand = @brand and Model = @model";
                command.Parameters.AddWithValue("@brand", vehicle.Brand);
                command.Parameters.AddWithValue("@model", vehicle.Model);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    idVehicle = (int)reader["Id"];
                }
            }

            return idVehicle;
        }
    }
}
