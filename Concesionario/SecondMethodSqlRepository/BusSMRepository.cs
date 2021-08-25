using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.SecondMethodSqlRepository
{
    class BusSMRepository : IBusDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino2; Integrated Security=true;";
        public void Delete(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "delete from Bus where Id = @id";
                command.Parameters.AddWithValue("@id", bus.Id);

                command.ExecuteReader();
            }
        }

        public List<Bus> Fetch()
        {
            List<Bus> buses = new List<Bus>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Bus";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var numberOfDoors = (int)reader["NumberOfSeats"];
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var id = (int)reader["Id"];

                    Bus bus = new Bus(numberOfDoors, brand, model, id);
                    buses.Add(bus);
                }
            }
            return buses;
        }

        public List<Bus> FetchStaticList()
        {
            throw new NotImplementedException();
        }

        public Bus GetById(int? id)
        {
            Bus buses = new Bus();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Bus where Id=@id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var numberOfSeats = (int)reader["NumberOfSeats"];
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];

                    buses = new Bus(numberOfSeats, brand, model, null);
                }
            }
            return buses;
        }

        public void Insert(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Bus values (@numberOfSeats, @brand, @model)";
                command.Parameters.AddWithValue("@numberOfSeats", bus.NumberOfSeats);
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Bus set NumberOfSeats = @numberOfSeats, Brand = @brand, Model = @model where Id=@id";
                command.Parameters.AddWithValue("@numberOfSeats", bus.NumberOfSeats);
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);
                command.Parameters.AddWithValue("@id", bus.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
