using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo
{
    class DisconnectedMode
    {
        string connectionString = @"Data Source = (localdb)\mssqllocaldb;" + "Initial Catalog = DemoAdo;" + "Integrated Security = true;";
        internal void fetch()
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(); //carica tutta la tabela e carica tutto su questo lato

                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = connection;
                selectCommand.CommandType = System.Data.CommandType.Text;
                selectCommand.CommandText = "select * from Book";

                adapter.SelectCommand = selectCommand;

                connection.Open();
                DataSet dataSet = new DataSet();

                adapter.Fill(dataSet, "Book");
                foreach (DataRow row in dataSet.Tables["Book"].Rows) //ciclare nei row nella tabella 
                {
                    var title = row["Title"];
                    var author = row["Author"];
                    var price = row["Price"];
                    var id = row["Id"];

                    Console.WriteLine($"{title} - {author}- {price} - {id}");
                }

            }
        }

        internal void Insert()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

            }
        }
    }
}
