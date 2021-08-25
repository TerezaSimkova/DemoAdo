using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.ThirdMethodRepository
{
    class MotorcycleTMRepository : IMotocycleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino3; Integrated Security=true;";

        const string _discriminator = "Motorcycle";

        public void Delete(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Vehicle where Id=@id";
                command.Parameters.AddWithValue("@id", motorcycle.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Motorcycle> Fetch() //ritorna una lista
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>();
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
                    var year = (int)reader["Year"];
                    var id = (int)reader["Id"];

                    Motorcycle motorcycle = new Motorcycle(year, brand, model, id);
                    motorcycles.Add(motorcycle);
                }

            }
            return motorcycles;


        }

        public List<Motorcycle> FetchStaticList()
        {
            throw new NotImplementedException();
        }

        public Motorcycle GetById(int? id)
        {
            Motorcycle motorcycles = new Motorcycle();
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
                    var year = (int)reader["Year"];
                    var Id = (int)reader["Id"];

                    motorcycles = new Motorcycle(year, brand, model, id);
                }
            }
            return motorcycles;
        }

        public void Insert(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Vehicle values (@brand,@model,@year,@supply,@numberOfDoors, @numberOfSeats, @discriminator)";
                command.Parameters.AddWithValue("@brand", motorcycle.Brand);
                command.Parameters.AddWithValue("@model", motorcycle.Model);
                command.Parameters.AddWithValue("@year", motorcycle.Year);
                command.Parameters.AddWithValue("@supply","");
                command.Parameters.AddWithValue("@numberOfDoors", "");
                command.Parameters.AddWithValue("@numberOfSeats","");
                command.Parameters.AddWithValue("@discriminator", "Motorcycle");

                command.ExecuteNonQuery();
            }
        }

        public void Update(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Vehicle set Year = @year, Brand = @brand, Model = @model, Supply = @supply, @numberOfDoors = @numberOfDoors, NumberOfSeats = @numberOfSaets, Id = @id, Discriminator = @discriminator";
                command.Parameters.AddWithValue("@brand", motorcycle.Brand);
                command.Parameters.AddWithValue("@model", motorcycle.Model);
                command.Parameters.AddWithValue("@year", motorcycle.Year);
                command.Parameters.AddWithValue("@supply", "");
                command.Parameters.AddWithValue("@numberOfDoors", "");
                command.Parameters.AddWithValue("@numberOfSeats", "");
                command.Parameters.AddWithValue("@discriminator", "Motorcycle");

                command.ExecuteNonQuery();
            }
        }
    }
}
