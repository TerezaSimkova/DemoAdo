using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DemoAdo
{
    class DbManagerConnectedMode
    {
        string connectionString = @"Data Source = (localdb)\mssqllocaldb;" + "Initial Catalog = DemoAdo;" + "Integrated Security = true;";
        public void fetch()
        {
            //server - copy my local db - (localdb)\mssqllocaldb
            //nome del db - DomeAdo



            using (SqlConnection connection = new SqlConnection(connectionString)) //crea mi connection alla stringa con mia database, se faccio using non devo chiudere connection
            {

                //apro la connection

                connection.Open();

                //dare i comandi SQL

                SqlCommand command = new SqlCommand();

                //prima di tutto definisco tipo di command la sua proprietá, in formato testo

                command.CommandType = System.Data.CommandType.Text;

                //asoccio commando alla connesione

                command.Connection = connection;

                //definisco la query

                command.CommandText = "select * from dbo.Book";

                SqlDataReader reader = command.ExecuteReader();

                //voglio stampare tutti i libri che ho a disposizione

                while (reader.Read())
                {
                    //per ogni righa leggo le colonne
                    var title = reader["Title"];
                    var author = reader["Author"];
                    var price = reader["Price"];
                    var id = reader["id"];


                    Console.WriteLine($"{title}, {author}, {price}, {id}");

                    //se non so nomi dei campi di db - uso posizione

                    var title2 = reader[0];
                    var author2 = reader[1];
                    var price2 = reader[2];
                    var íd2 = reader[3];

                }


                //chiudo connection se non ce using all inizio

                //connection.Close();
            }

        }

        public void GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.CommandType = System.Data.CommandType.Text;

                command.Connection = connection;

                //ai parametri posso dare il nome che voglio  precedute da @
                command.CommandText = "select * from dbo.Book where id = @id";

                //se ho parametri vado a definirli
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var title = reader["Title"];
                    var author = reader["Author"];
                    var price = reader["Price"];
                    var id2 = reader["id"];

                    Console.WriteLine($"{title}, {author}, {price}, {id2}");
                }
            }
        }

        public void Insert(string title, string author, double price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "insert into dbo.Book values(@title,@author,@price)";

                command.Parameters.AddWithValue("@title", title); // dico che @title é la mie variabile title
                command.Parameters.AddWithValue("@author", author); // dico che @title é la mie variabile title
                command.Parameters.AddWithValue("@price", price); // dico che @title é la mie variabile title

                //non m iaspetto nessuan righa di ritorno(non legge nulla) perché é come se fosse nel sql, da solo la conferma ché inserito
                command.ExecuteNonQuery();
            }
        }

        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete dbo.Book where id = @id";
                command.Parameters.AddWithValue("@id", id);


                command.ExecuteNonQuery();
            }
        }

        public void Update(Book book)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "update dbo.Book set Title = @title, Author = @author,Price = @price where id=@id";
                command.Parameters.AddWithValue("@title", book.title);
                command.Parameters.AddWithValue("@Author", book.author);
                command.Parameters.AddWithValue("@Price", book.price);
                command.Parameters.AddWithValue("@id", book.id);


                command.ExecuteNonQuery();
            }

        }

        public void Count()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "select count(*) from dbo.Book";

                int numBooks = (int)command.ExecuteScalar(); //metto cast perché non riconsce che tipo é da solo
            }
        }

        //public void CountWithCrud()
        //{
        //    fetch();
        //}

    }
}
