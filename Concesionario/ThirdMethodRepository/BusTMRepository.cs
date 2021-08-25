using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.ThirdMethodRepository
{
    class BusTMRepository : IBusDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino3; Integrated Security=true;";

        const string _discriminator = "Bus"; //costante per il discriminator

        public void Delete(Bus bus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Vehicle where Id=@id";
                command.Parameters.AddWithValue("@id", bus.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Bus> Fetch()
        {
            List<Bus> buses = new List<Bus>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Vehicle where Discriminator = @dicriminator";
                command.Parameters.AddWithValue("@dicriminator", _discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var numberOfSeats = (int)reader["NumberOfSeats"];
                    var id = (int)reader["Id"];

                    Bus bus = new Bus(numberOfSeats, brand, model, id);
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
                command.CommandText = "select * from Vehicle where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var numberOfSeats = (int)reader["NumberOfSeats"];
                    var Id = (int)reader["Id"];

                    buses = new Bus(numberOfSeats, brand, model, id);
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
                command.CommandText = "insert into Vehicle values (@brand,@model,@year,@supply,@numberOfDoors, @numberOfSeats, @discriminator)";
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);
                command.Parameters.AddWithValue("@year", DBNull.Value);
                command.Parameters.AddWithValue("@supply", DBNull.Value);
                command.Parameters.AddWithValue("@numberOfSeats", bus.NumberOfSeats);
                command.Parameters.AddWithValue("@numberOfDoors", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

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
                command.CommandText = "update Vehicle set Year = @year, Brand = @brand, Model = @model, Supply = @supply, @numberOfDoors = @numberOfDoors, NumberOfSeats = @numberOfSaets, Id = @id, Discriminator = @discriminator";
                command.Parameters.AddWithValue("@brand", bus.Brand);
                command.Parameters.AddWithValue("@model", bus.Model);
                command.Parameters.AddWithValue("@year", DBNull.Value);
                command.Parameters.AddWithValue("@numberOfSeats", DBNull.Value);
                command.Parameters.AddWithValue("@supply", bus.NumberOfSeats);
                command.Parameters.AddWithValue("@numberOfDoors", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }
    }
}
