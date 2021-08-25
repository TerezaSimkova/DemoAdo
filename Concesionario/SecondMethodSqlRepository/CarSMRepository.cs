using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Concesionario.Car;

namespace Concesionario.SecondMethodSqlRepository
{
    class CarSMRepository : ICarDbManager
    {

        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino2; Integrated Security=true;";
        public void Delete(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Car where Id = @id";
                command.Parameters.AddWithValue("@id", car.Id);

                command.ExecuteReader();
            }
        }

        public List<Car> Fetch()
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Car";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var supply = (int)reader["Supply"];
                    var numberOfDoors = (int)reader["NumberOfDoors"];
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var id = (int)reader["Id"];

                    Car car = new Car((PowerSupply)supply,numberOfDoors,brand,model,id);
                    cars.Add(car);
                }
            
                return cars;
            }
        }

        public List<Car> FetchStaticList()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int? id)
        {
            Car car = new Car();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Car where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var supply = (int)reader["Supply"];
                    var numberOfDoors = (int)reader["NumberOfDoors"];
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];

                    car = new Car((PowerSupply)supply,numberOfDoors, brand, model,null);
                }
            }
            return car;
        }

        public void Insert(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Car values (@brand, @model, @supply, @numberOfDoors)"; // importante ordine! Secondo database!
                command.Parameters.AddWithValue("@supply", (int)car.Supply);
                command.Parameters.AddWithValue("@numberOfDoors", car.NumberOfDoors);
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);


                command.ExecuteNonQuery();
            }
        }

        public void Update(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Car set Brand = @brand, Model = @model, Supply = @supply, NumberOfDoors = @numberOfDoors where Id = @id"; // importante ordine! Secondo database!
                command.Parameters.AddWithValue("@supply", (int)car.Supply);
                command.Parameters.AddWithValue("@numberOfDoors", car.NumberOfDoors);
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@id", car.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
