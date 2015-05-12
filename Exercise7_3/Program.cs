using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new Book[3];
            books[0] = new Book("Programming C# 3.0", "Jesse Liberty and Donald Xie", "9139312591293");
            books[1] = new Book("Programming C# 4.0", "Jesse Liberty and Donald Xie", "9139312591293");
            books[2] = new Book("Programming C# 5.0", "Jesse Liberty and Donald Xie", "9139312591293");

            foreach (var book in books)
            {
                book.DisplayBook();
            }
        }
    }

    class Book
    {
        private String publisher = "O'Reilly";

        public String Title { get; set; }
        public String Author { get; set; }
        public String Publisher { get { return publisher; } set { publisher = value; } }
        public String ISBN { get; set; }

        public Book(String title, String author, String isbn)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
        }

        public void DisplayBook() 
        {
            Console.WriteLine("{0} \t {1} \t {2} \t {3}", Title, Author, Publisher, ISBN);
        }
    }

}
