using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.SecondMethodSqlRepository
{
    class MotorcycleSMRepository : IMotocycleDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino2; Integrated Security=true;"; //cambio database
        public void Delete(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "delete from Motorcycle where Id = @id";
                command.Parameters.AddWithValue("@id", motorcycle.Id);

                command.ExecuteReader();
            }
        }

        public List<Motorcycle> Fetch()
        {
            List<Motorcycle> motorcycles = new List<Motorcycle>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Motorcycle";

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
            Motorcycle motorcycle = new Motorcycle();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from motorcycle where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var year = (int)reader["Year"];
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];

                    motorcycle = new Motorcycle(year, brand, model,null);
                }
            }
            return motorcycle;
        }

        public void Insert(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "insert into Motorcycle values (@brand, @model, @year)";
               
                command.Parameters.AddWithValue("@brand", motorcycle.Brand);
                command.Parameters.AddWithValue("@model", motorcycle.Model);
                command.Parameters.AddWithValue("@year", motorcycle.Year);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Motorcycle motorcycle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "update Motorcycle set Year = @year, Brand = @brand, Model = @model where Id = @id";
                command.Parameters.AddWithValue("@year", motorcycle.Year);
                command.Parameters.AddWithValue("@brand", motorcycle.Brand);
                command.Parameters.AddWithValue("@model", motorcycle.Model);
                command.Parameters.AddWithValue("@id", motorcycle.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
