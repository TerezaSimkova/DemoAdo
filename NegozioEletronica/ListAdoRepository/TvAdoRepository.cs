using NegozioEletronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioEletronica.ListAdoRepository
{
    class TvAdoRepository : ITvRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=NegozioElettronica; Integrated Security=true;";

        const string _discriminator = "Tv";

        public void Delete(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Phone where Id=@id";
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Tv> Fetch()
        {
            List<Phone> phones = new List<Phone>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Tv where Discriminator = @dicriminator";
                command.Parameters.AddWithValue("@dicriminator", _discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var  = (int)reader[""];

                    Phone phone = new Phone();
                    phones.Add(phone);
                }

            }
            return phones;
        }

        public void Insert(Tv tv)
        {
            throw new NotImplementedException();
        }

        public void Update(Tv tv)
        {
            throw new NotImplementedException();
        }
    }
}
