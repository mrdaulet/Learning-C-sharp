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
            // I have two comments:

            // 1st Point:
            // I would definitely use a List<> here instead of an array. There are very few occasions on which I'd use an array in fact.
            // For a general collection a List is a much more flexible object, and is definitely the de facto "Default Concrete Collection".
            // Beyond that IEnumberable<> is pretty much the default type for a collection being passed around as a parameter.
            //
            // The only cases that come to mind for using an array are either:
            //   - you're using legacy code that forces you to do so to match a method Signature. And even then, I'd use a List and call .ToArray() at the last moment.
            //   - or if using a array gives semantic meaning. An array is a collection with is accessed by order-based index. If you're going to be getting the nth object and the kth object a lot then using an array is sensible.
            // Note that if you're indexing into it but not based on order you want a Dictionary :)

            // 2nd Point:
            // Object initialisation.
            // Both Arrays and Lists (and in fact Dictionaries, and I suspect most other "collection" types) have an object initialisation syntax, which is much nicer. See below.

            var books = new List<Book> {
                new Book("Programming C# 3.0", "Jesse Liberty and Donald Xie", "9139312591293"),
                new Book("Programming C# 4.0", "Jesse Liberty and Donald Xie", "9139312591293"),
                new Book("Programming C# 5.0", "Jesse Liberty and Donald Xie", "9139312591293")
            };

            foreach (var book in books)
            {
                book.DisplayBook();
            }
        }
    }

    class Book
    {
        // This is what the question told you to do, but I hope it's obvious that it would be a terrible idea in reality.
        // Even if all the books you have at the moment are OReilly books there's nothing about the concept of a "Book" that should constrain it to being an O'Reilly book.
        // A potentially more realistic way to design this code might be to have a Book class that makes no assumptions about it's publisher, and then have a sub-class called OReillyBook which sets the publisher in its constructor.
        private String publisher = "O'Reilly";

        public String Title { get; set; }
        public String Author { get; set; }
        //This is fine. Another design option would be to have this as just another default Property and have the publisher set in the Constructor.
        // Given that you already have a constructor and all the other properties are auto properties, I'd be inclined to go that route.
        public String Publisher { get { return publisher; } set { publisher = value; } }
        public String ISBN { get; set; }

        public Book(String title, String author, String isbn)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
        }

        //If we're allowing setting of the publisher (which I think is appropriate), then we should allow it in a constructor overload too.
        public Book(String title, String author, String isbn, String publisher) : this(title, author, isbn)
        {
            this.publisher = publisher;
        }
        
        // There are two pieces of logic in here:
        // 1: <This> is how we format this class if we want it as a string.
        // 2: If we want to "Diplay" the book then we do so on the console.
        // I think it's definitely worth separating these two things, especially as the first already has a widely recognised name ... it's the override of the object.ToString() method.

        // Also worth noting that in general, in a real project we wouldn't want to have a reference to Console in a class - we want the class to be usable everywhere and not all environments will have a console.
        // Also - it makes the code very difficult to test (it's extremely hard to check what has been written to the console).
        // Instead, either the writing to console would be the responsibility of the some calling code somewhere else, that would be using the ToString() method,
        // or we would pass into this method some sort of Logging object which is responsible for working out how to do logging in the current environment.
        // In the latter case, we would pass in some sort of dummy logger for tests, which just keeps an in-memory record of what was "logged" which we can then check for the Assert part of the test.
        public void DisplayBook()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return string.Format("{0} \t {1} \t {2} \t {3}", Title, Author, Publisher, ISBN);
        }
    }

}
