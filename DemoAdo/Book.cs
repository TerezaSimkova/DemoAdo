using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAdo
{
    class Book
    {

            public string title { get; set; }
            public string author { get; set; }
            public double price { get; set; }
            public int id { get; set; }

            public Book(string title, string author, double price, int id)
            {
                title = title;
                author = author;
                price = price;
                id = id;
            }

    }
}
