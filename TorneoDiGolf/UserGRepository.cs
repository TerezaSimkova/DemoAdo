using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoDiGolf
{

    class UserGRepository : IUserDbManager<User>
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=GolfClub; Integrated Security=true;";


        public void Delete(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from User where Id=@id";
                command.Parameters.AddWithValue("@id", user.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<User> Fetch()
        {
            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Users";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {                    
                    var id = (int)reader["Id"];
                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var dateOfBirth = (DateTime)reader["DateOfBirth"];
                    var gender = (EnumGender)reader["Gender"];
                    var clubCard = (bool)reader["ClubCard"];

                    User user = new User(id, name, surname, dateOfBirth, gender, clubCard); 
                    users.Add(user);
                }

            }
            return users;
        }

        public User GetById(int? id)
        {
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from User where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    var name = (string)reader["Name"];
                    var surname = (string)reader["Surname"];
                    var dateOfBirth = (DateTime)reader["DateOfBirth"];
                    var gender = (EnumGender)reader["Gender"];
                    var clubCard = (bool)reader["ClubCard"];

                    user = new User(id,name, surname, dateOfBirth, gender, clubCard);
                }

            }
            return user;
        }

        public void Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into User values (@name,@surname,@dateOfBirth,@gender,@clubCard)";
                command.Parameters.AddWithValue("@name",user.Name);
                command.Parameters.AddWithValue("@surname",user.Surname);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@gender", user.Gender);
                command.Parameters.AddWithValue("@clubCard", user.ClubCard);


                command.ExecuteNonQuery();
            }
        }

        public void Update(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update User set Name = @name, Surname = @surname, DateOfBirth = @dateOfBirth,Gender = @gender, ClubCard = @clubCard)";
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@gender", user.Gender);
                command.Parameters.AddWithValue("@clubCard", user.ClubCard);


                command.ExecuteNonQuery();
            }
        }
    }
}
