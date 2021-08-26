
using NegozioEletronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NegozioEletronica.ListAdoRepository
{
    class PhoneAdoRepository : IPhoneRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=NegozioElettronica; Integrated Security=true;";

        const string _discriminator = "Phone";

        public void Delete(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Phone where Id=@id";
                command.Parameters.AddWithValue("@id", phone.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Phone> Fetch()
        {
            List<Phone> phones = new List<Phone>();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Phone where Discriminator = @dicriminator";
                command.Parameters.AddWithValue("@dicriminator", _discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var memoryGB = (int)reader["MemoryGB"];

                    Phone phone = new Phone();
                    phones.Add(phone);
                }

            }
            return phones;
        }

        public void Insert(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Phone values (@brand,@model,@memoryGB,@opsystem,@touch,inchTv,@discriminator)";
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@model", phone.Model);
                command.Parameters.AddWithValue("@memoryGB", phone.MemoryGB);
                command.Parameters.AddWithValue("@opsystem", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inchTv", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Phone set Brand = @brand,Model = @model, MemoryGB = @memoryGB,OPSystem = @opsystem, Touch = @touch, InchTV = inchTv, Discriminator = @discriminator";
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@model", phone.Model);
                command.Parameters.AddWithValue("@memoryGB", phone.MemoryGB);
                command.Parameters.AddWithValue("@opsystem", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inchTv", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();
            }
        }

    }
}
