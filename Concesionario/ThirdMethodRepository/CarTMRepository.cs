using Concesionario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Concesionario.Car;

namespace Concesionario.ThirdMethodRepository
{
   

    class CarTMRepository : ICarDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Magazzino3; Integrated Security=true;";

        const string _discriminator = "Car";


        public void Delete(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Vehicle where Id=@id";
                command.Parameters.AddWithValue("@id", car.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Car> Fetch()
        {
            List<Car> cars = new List<Car>();
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
                    var supply = (PowerSupply)reader["Supply"];
                    var numberOfDoors = (int)reader["NumberOfDoors"];
                    var id = (int)reader["Id"];

                    Car car = new Car(supply,numberOfDoors, brand, model, id);
                    cars.Add(car);
                }

            }
            return cars;
        }

        public List<Car> FetchStaticList()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int? id)
        {
            Car cars = new Car();
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
                    var supply = (PowerSupply)reader["Supply"];
                    var numberOfDoors = (int)reader["NumberOfDoors"];
                    var Id = (int)reader["Id"];

                    cars = new Car(supply,numberOfDoors, brand, model, id);
                }
            }
            return cars;
        }

        public void Insert(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Vehicle values (@brand,@model,@year,@supply,@numberOfDoors, @numberOfSeats, @discriminator)";
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@year", car.Supply);
                command.Parameters.AddWithValue("@numberOfSeats", DBNull.Value);
                command.Parameters.AddWithValue("@supply", car.NumberOfDoors);
                command.Parameters.AddWithValue("@numberOfDoors", DBNull.Value);          
                command.Parameters.AddWithValue("@discriminator", _discriminator);

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
                command.CommandText = "update Vehicle set Year = @year, Brand = @brand, Model = @model, Supply = @supply, @numberOfDoors = @numberOfDoors, NumberOfSeats = @numberOfSaets, Id = @id, Discriminator = @discriminator";
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@year", car.Supply);
                command.Parameters.AddWithValue("@supply", car.NumberOfDoors);
                command.Parameters.AddWithValue("@numberOfDoors", DBNull.Value);
                command.Parameters.AddWithValue("@numberOfSeats", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }
    }
}
